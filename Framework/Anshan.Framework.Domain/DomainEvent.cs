using System;

namespace Anshan.Framework.Domain
{
    public abstract class DomainEvent
    {
        public Guid EventId { get; private set; }

        public DateTime EventPublishDateTime { get; private set; }

        protected DomainEvent()
        {
            this.EventId = Guid.NewGuid();
            this.EventPublishDateTime = DateTime.Now;
        }
    }
}