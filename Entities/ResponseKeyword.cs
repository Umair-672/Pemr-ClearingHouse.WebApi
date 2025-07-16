using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class ResponseKeyword : BaseEntity
    {
        [BsonElement("Keyword")]
        public string Keyword { get; set; } = null!;
        [BsonElement("InterpretedText")]
        public string InterpretedText { get; set; } = null!;
        [BsonElement("Status")]
        public string Status { get; set; } = null!;
        [BsonElement("SourceID")]
        public string SourceID { get; set; } = null!;
    }
} 