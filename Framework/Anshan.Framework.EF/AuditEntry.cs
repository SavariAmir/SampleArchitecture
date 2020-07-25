using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Anshan.Framework.EF
{
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        public EntityEntry Entry { get; }

        public string TableName { get; set; }

        public Dictionary<string, object> Values { get; } = new Dictionary<string, object>();

        public Audit ToAudit()
        {
            var audit = new Audit
            {
                AggregateRootName = TableName,
                //CreatedAt = DateTime.UtcNow,
                Values = Values.Count == 0 ? null : JsonConvert.SerializeObject(Values.Values),
            };
            return audit;
        }
    }
}