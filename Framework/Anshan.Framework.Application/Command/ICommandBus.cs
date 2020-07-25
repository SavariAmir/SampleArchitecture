using System.Threading.Tasks;

namespace Anshan.Framework.Application.Command
{
    public interface ICommandBus
    {
        Task Dispatch<T>(T command);
    }
}