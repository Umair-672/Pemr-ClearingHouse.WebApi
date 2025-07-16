using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class ResponseKeywordField : BaseEntity
    {
        [ForeignKey("ResponseKeywordID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ResponseKeywordID { get; set; } = null!;
        [BsonIgnore]
        public ResponseKeyword? ResponseKeyword { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string FieldID { get; set; } = null!;
    }
} 