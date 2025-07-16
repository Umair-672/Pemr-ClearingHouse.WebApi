using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class Gateway : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; } = null!;
        [BsonElement("GatewayType")]
        public string GatewayType { get; set; } = null!;
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
        [BsonElement("IsDeleted")]
        public bool IsDeleted { get; set; }
    }
} 