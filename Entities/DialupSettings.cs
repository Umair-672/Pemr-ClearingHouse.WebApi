using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class DialupSettings : BaseEntity
    {
        [BsonElement("ConnectionName")]
        public string ConnectionName { get; set; } = null!;
        [BsonElement("DialingNumber")]
        public string DialingNumber { get; set; } = null!;
        [BsonElement("UserName")]
        public string UserName { get; set; } = null!;
        [BsonElement("Password")]
        public string Password { get; set; } = null!;
    }
} 