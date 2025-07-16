using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class VPNSettings : BaseEntity
    {
        [ForeignKey("GatewayID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string GatewayID { get; set; } = null!;
        [BsonIgnore]
        public Gateway? Gateway { get; set; }
        [BsonElement("ConnectionName")]
        public string ConnectionName { get; set; } = null!;
        [BsonElement("IPAddress")]
        public string IPAddress { get; set; } = null!;
        [BsonElement("UserName")]
        public string UserName { get; set; } = null!;
        [BsonElement("Password")]
        public string Password { get; set; } = null!;
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
        [BsonElement("IsDeleted")]
        public bool IsDeleted { get; set; }
    }
} 