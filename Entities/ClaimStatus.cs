using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class ClaimStatus : BaseEntity
    {
        [ForeignKey("OutboundClaimID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OutboundClaimID { get; set; } = null!;
        [BsonIgnore]
        public OutboundClaim? OutboundClaim { get; set; }
        [BsonElement("Status")]
        public string Status { get; set; } = null!;
        [BsonElement("ResponseText")]
        public string ResponseText { get; set; } = null!;
    }
} 