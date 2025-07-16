using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PemrClearingHouse.Api.Entities
{
    public class Organization : BaseEntity
    {
        [BsonElement("OrganizationName")]
        public string OrganizationName { get; set; } = null!;
        [BsonElement("Address")]
        public string Address { get; set; } = null!;
        [BsonElement("Email")]
        public string Email { get; set; } = null!;
        [BsonElement("Phone")]
        public string Phone { get; set; } = null!;
        public bool IsActive { get; set; }

    }
}
