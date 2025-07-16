using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class FTPSettings : BaseEntity
    {
        [ForeignKey("GatewayID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string GatewayID { get; set; } = null!;
        [BsonIgnore]
        public Gateway? Gateway { get; set; }
        [BsonElement("SubmitterID")]
        public string SubmitterID { get; set; } = null!;
        [BsonElement("URL")]
        public string URL { get; set; } = null!;
        [BsonElement("UserName")]
        public string UserName { get; set; } = null!;
        [BsonElement("Password")]
        public string Password { get; set; } = null!;
        [BsonElement("ClaimDir")]
        public string ClaimDir { get; set; } = null!;
        [BsonElement("ClaimStatusDir")]
        public string ClaimStatusDir { get; set; } = null!;
        [BsonElement("EligibilityDir")]
        public string EligibilityDir { get; set; } = null!;
        [BsonElement("ERADir")]
        public string ERADir { get; set; } = null!;
        [BsonElement("OutboundFileType")]
        public string OutboundFileType { get; set; } = null!;
        [BsonElement("InboundFileType")]
        public string InboundFileType { get; set; } = null!;
        [BsonElement("EncryptionPublicKey")]
        public string EncryptionPublicKey { get; set; } = null!;
        [BsonElement("EncryptionPrivateKey")]
        public string EncryptionPrivateKey { get; set; } = null!;
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
        [BsonElement("IsDeleted")]
        public bool IsDeleted { get; set; }
    }
} 