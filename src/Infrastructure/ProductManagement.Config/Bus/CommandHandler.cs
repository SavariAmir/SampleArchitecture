using Anshan.Framework.Application.Command;
using System.Threading.Tasks;

namespace ProductManagement.Config.Bus
{
    public class CommandHandler<T> : ICommandHandler<T>
    {
        private readonly ICommandHandler<T> _commandHandler;

        public CommandHandler(ICommandHandler<T> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public async Task Handle(T command)
        {
            await _commandHandler.Handle(command);
        }
    }
}