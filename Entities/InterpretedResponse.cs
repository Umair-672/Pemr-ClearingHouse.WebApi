using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class InterpretedResponse : BaseEntity
    {
        [ForeignKey("ClaimStatusID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClaimStatusID { get; set; } = null!;
        [BsonIgnore]
        public ClaimStatus? ClaimStatus { get; set; }
        [ForeignKey("ResponseKeywordID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ResponseKeywordID { get; set; } = null!;
        [BsonIgnore]
        public ResponseKeyword? ResponseKeyword { get; set; }
        [BsonElement("Status")]
        public string Status { get; set; } = null!;
        [BsonElement("InterpretedText")]
        public string InterpretedText { get; set; } = null!;
    }
} 