using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class X12Transaction : BaseEntity
    {
        [ForeignKey("X12StandardID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string X12StandardID { get; set; } = null!;
        [BsonIgnore]
        public X12Standard? X12Standard { get; set; }
        [BsonElement("Transaction")]
        public string Transaction { get; set; } = null!;
        [BsonElement("TransactionCode")]
        public string TransactionCode { get; set; } = null!;
    }
} 