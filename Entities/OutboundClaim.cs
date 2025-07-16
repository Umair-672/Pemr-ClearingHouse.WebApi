using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class OutboundClaim : BaseEntity
    {
        [ForeignKey("OutboundTransactionID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OutboundTransactionID { get; set; } = null!;
        [BsonIgnore]
        public OutboundTransaction? OutboundTransaction { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClaimID { get; set; } = null!;
        [BsonIgnore]
        public Claim? Claim { get; set; }
    }
} 