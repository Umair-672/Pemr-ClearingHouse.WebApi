using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class InterpretationEntity : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; } = null!;
        [BsonElement("Code")]
        public string Code { get; set; } = null!;
    }
} 