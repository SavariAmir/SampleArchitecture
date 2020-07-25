using Anshan.Framework.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace ProductManagement.Persistence.Mongo
{
    public class MapClass
    {
        public static void Map()
        {
            BsonClassMap.RegisterClassMap<Entity<string>>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id);
                cm.MapMember(c => c.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
                cm.MapMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            });
        }
    }
}