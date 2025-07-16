using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class Insurance : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; } = null!;
        [BsonElement("InsuranceType")]
        public string InsuranceType { get; set; } = null!;
        [BsonElement("FilingIndicator")]
        public string FilingIndicator { get; set; } = null!;
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
        [BsonElement("IsDeleted")]
        public bool IsDeleted { get; set; }
    }
} 