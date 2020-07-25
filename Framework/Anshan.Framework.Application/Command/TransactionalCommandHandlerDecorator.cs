using System;
using System.Threading.Tasks;
using Anshan.Framework.Core;

namespace Anshan.Framework.Application.Command
{
    public class TransactionalCommandHandlerDecorator<T> : ICommandHandler<T>
    {
        private readonly ICommandHandler<T> _commandHandler;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionalCommandHandlerDecorator(ICommandHandler<T> commandHandler,
            IUnitOfWork unitOfWork)
        {
            _commandHandler = commandHandler;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(T command)
        {
            _unitOfWork.Begin();

            try
            {
                await _commandHandler.Handle(command);
                await _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                _unitOfWork.Rollback();
                throw new Exception(exception.Message, exception);
            }
        }
    }

    public class PermissionCommandHandlerDecorator<T> : ICommandHandler<T>
    {
        private readonly ICommandHandler<T> _commandHandler;

        public PermissionCommandHandlerDecorator(ICommandHandler<T> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public async Task Handle(T command)
        {
            await _commandHandler.Handle(command);
        }
    }
}