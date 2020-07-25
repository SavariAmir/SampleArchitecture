using Anshan.Framework.Core;
using System.Threading.Tasks;

namespace ProductManagement.Config.Bus
{
    public class MyCommandBus : IMyCommandBus
    {
        private readonly IServiceLocator _serviceLocator;

        public MyCommandBus(IServiceLocator serviceLocator)
        {
            this._serviceLocator = serviceLocator;
        }

        public async Task Dispatch<T>(T command)
        {
            var handler = _serviceLocator.GetInstance<CommandHandler<T>>();
            await handler.Handle(command);
            _serviceLocator.Release(handler);
        }
    }
}