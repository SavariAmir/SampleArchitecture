using Anshan.Framework.Core;
using System;

namespace Anshan.Framework.DI
{
    public class DotNetCoreServiceLocatorAdapter : IServiceLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public DotNetCoreServiceLocatorAdapter(IServiceProvider services)
        {
            _serviceProvider = services;
        }

        public T GetInstance<T>()
        {
            var service = (T)_serviceProvider.GetService(typeof(T));
            return service;
        }

        public void Release(object obj)
        {
        }
    }
}