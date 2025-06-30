using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PemrClearingHouse.Api.Entities
{
    public class OrganizationEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonRequired]
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; } = null!;
    }
}
