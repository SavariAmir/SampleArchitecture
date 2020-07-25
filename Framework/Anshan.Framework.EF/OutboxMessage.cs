using System;

namespace Anshan.Framework.EF
{
    public class OutboxMessage
    {
        public Guid Id { get; set; }

        public DateTime EventPublishDateTime { get; private set; }

        public DateTime ProcessedDate { get; private set; }

        public bool IsProcessed { get; private set; }

        public string Type { get; private set; }

        public string Data { get; private set; }

        private OutboxMessage()
        {
        }

        internal OutboxMessage(DateTime eventPublishDateTime, string type, string data)
        {
            this.Id = Guid.NewGuid();
            this.EventPublishDateTime = eventPublishDateTime;
            this.Type = type;
            this.Data = data;
        }
    }
}