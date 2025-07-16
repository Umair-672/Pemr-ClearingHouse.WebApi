using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class X12Standard : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; } = null!;
    }
} 