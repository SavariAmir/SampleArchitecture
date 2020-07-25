using Anshan.Framework.Core.Events;

namespace Anshan.Framework.EF
{
    public class EntityCreated : IEvent
    {
        public int Id { get; private set; }

        public EntityCreated(int id)
        {
            Id = id;
        }
    }
}