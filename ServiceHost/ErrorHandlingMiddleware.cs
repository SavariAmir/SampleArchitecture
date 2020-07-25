using Anshan.Framework.Domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ServiceHost
{
    public sealed class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var errorCode = ErrorCode.InternalServerError;

            if (exception is DomainException)
            {
                code = HttpStatusCode.BadRequest;
                errorCode = ErrorCode.BadRequest;
            }

            var errorResponse = ErrorResponse.Create(exception.Message, errorCode);
            var result = JsonConvert.SerializeObject(errorResponse);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }

    public static class ErrorWrappingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorWrappingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }

    public class ErrorResponse
    {
        public string Message { get; private set; }

        public ErrorCode Code { get; private set; }

        //public List<ErrorResponseItem> Details { get; private set; }

        //public ErrorResponse(string message, ErrorCode code, List<ErrorResponseItem> details)
        //{
        //    Message = message;
        //    Code = code;
        //    //Details = details;
        //}

        public ErrorResponse(string message, ErrorCode code)
        {
            Message = message;
            Code = code;
        }

        public static ErrorResponse Create(string message, ErrorCode code)
        {
            var response = new ErrorResponse(message, code);
            return response;
        }
    }

    public enum ErrorCode
    {
        None = 0,
        InvalidModel = 1,
        ObjectNotFound = 4,
        InternalServerError = 5,
        BadRequest = 6
    }

    public class ErrorResponseItem
    {
        public string Message { get; set; }

        public ErrorCode Code { get; set; }

        public ErrorResponseItem(string message, ErrorCode code)
        {
            Message = message;
            Code = code;
        }
    }
}