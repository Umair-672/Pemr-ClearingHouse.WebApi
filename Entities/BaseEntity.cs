using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PemrClearingHouse.Api.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null!;
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
        public string? CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; } = null!;
    }
}
