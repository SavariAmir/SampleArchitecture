using System.Threading.Tasks;

namespace ProductManagement.Config.Bus
{
    public interface IMyCommandBus
    {
        Task Dispatch<T>(T command);
    }
}