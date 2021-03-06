﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Anshan.Framework.Application
{
    public static class RepositoryRegistration
    {
        public static void AddRepositories<T>(this IServiceCollection services)
        {
            var handlerTypes = typeof(T).Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(IsHandlerInterface))
                .Where(x => x.Name.EndsWith("Repository"))
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
            var type = attribute.GetType();

            //if (type == typeof(AuditLogAttribute))
            //    return typeof(AuditLoggingDecorator<>);

            // other attributes go here

            throw new ArgumentException(attribute.ToString());
        }

        private static bool IsHandlerInterface(Type type)
        {
            return typeof(IRepository).IsAssignableFrom(type);
        }
    }
}