using Anshan.Framework.Core;
using Castle.Windsor;

namespace Anshan.Framework.EF
{
    public class WindsorServiceLocatorAdapter : IServiceLocator
    {
        private readonly IWindsorContainer _container;

        public WindsorServiceLocatorAdapter(IWindsorContainer container)
        {
            this._container = container;
        }

        public T GetInstance<T>()
        {
            return _container.Resolve<T>();
        }

        public void Release(object obj)
        {
            _container.Release(obj);
        }
    }
}