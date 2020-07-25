using Anshan.Framework.Core;
using System.Threading.Tasks;

namespace Anshan.Framework.Application.Command
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceLocator _serviceLocator;

        public CommandBus(IServiceLocator serviceLocator)
        {
            this._serviceLocator = serviceLocator;
        }

        public async Task Dispatch<T>(T command)
        {
            var handler = _serviceLocator.GetInstance<TransactionalCommandHandlerDecorator<T>>();
            await handler.Handle(command);
            _serviceLocator.Release(handler);
        }
    }
}