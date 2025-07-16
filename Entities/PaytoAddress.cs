using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class PaytoAddress : BaseEntity
    {
        [ForeignKey("InboundTransactionID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InboundTransactionID { get; set; } = null!;
        [BsonIgnore]
        public InboundTransaction? InboundTransaction { get; set; }
        [BsonElement("EntityTypeQualifier")]
        public string EntityTypeQualifier { get; set; } = null!;
        [BsonElement("Address1")]
        public string Address1 { get; set; } = null!;
        [BsonElement("Address2")]
        public string Address2 { get; set; } = null!;
        [BsonElement("City")]
        public string City { get; set; } = null!;
        [BsonElement("State")]
        public string State { get; set; } = null!;
        [BsonElement("ZipCode")]
        public string ZipCode { get; set; } = null!;
    }
} 