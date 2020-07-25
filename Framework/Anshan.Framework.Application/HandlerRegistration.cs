using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Anshan.Framework.Application.Command;
using Microsoft.Extensions.DependencyInjection;

namespace Anshan.Framework.Application
{
    public static class HandlerRegistration
    {
        public static void AddHandlers<T>(this IServiceCollection services)
        {
            var handlerTypes = typeof(T).Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(IsHandlerInterface))
                .Where(x => x.Name.EndsWith("Handler"))
                .ToList();

            foreach (var type in handlerTypes)
            {
                AddHandler(services, type);
            }
        }

        private static void AddHandler(IServiceCollection services, Type type)
        {
            var attributes = type.GetCustomAttributes(false);

            var pipeline = attributes
                .Select(ToDecorator)
                .Concat(new[] { type })
                .Reverse()
                .ToList();

            var interfaces = type.GetInterfaces().Where(IsHandlerInterface);

            foreach (var interfaceType in interfaces)
            {
                var factory = BuildPipeline(pipeline, interfaceType);

                services.AddTransient(interfaceType, factory);
            }
        }

        private static Func<IServiceProvider, object> BuildPipeline(IEnumerable<Type> pipeline, Type interfaceType)
        {
            var ctors = pipeline
                .Select(x =>
                {
                    var type = x.IsGenericType ? x.MakeGenericType(interfaceType.GenericTypeArguments) : x;
                    return type.GetConstructors().Single();
                })
                .ToList();

            object Func(IServiceProvider provider)
            {
                object current = null;

                foreach (var ctor in ctors)
                {
                    var parameterInfos = ctor.GetParameters().ToList();

                    var parameters = GetParameters(parameterInfos, current, provider);

                    current = ctor.Invoke(parameters);
                }

                return current;
            }

            return Func;
        }

        private static object[] GetParameters(IReadOnlyList<ParameterInfo> parameterInfos, object current, IServiceProvider provider)
        {
            var result = new object[parameterInfos.Count];

            for (int i = 0; i < parameterInfos.Count; i++)
            {
                result[i] = GetParameter(parameterInfos[i], current, provider);
            }

            return result;
        }

        private static object GetParameter(ParameterInfo parameterInfo, object current, IServiceProvider provider)
        {
            var parameterType = parameterInfo.ParameterType;

            if (IsHandlerInterface(parameterType))
                return current;

            var service = provider.GetService(parameterType);
            if (service != null)
                return service;

            throw new ArgumentException($"Type {parameterType} not found");
        }

        private static Type ToDecorator(object attribute)
        {
            return typeof(TransactionalCommandHandlerDecorator<>);
        }

        private static bool IsHandlerInterface(Type type)
        {
            if (!type.IsGenericType)
                return false;

            var typeDefinition = type.GetGenericTypeDefinition();

            return typeDefinition == typeof(ICommandHandler<>);
        }
    }
}