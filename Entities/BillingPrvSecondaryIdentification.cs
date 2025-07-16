using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class BillingPrvSecondaryIdentification : BaseEntity
    {
        [ForeignKey("BillingProviderID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BillingProviderID { get; set; } = null!;
        [BsonIgnore]
        public BillingProvider? BillingProvider { get; set; }
        [BsonElement("Qualifier")]
        public string Qualifier { get; set; } = null!;
        [BsonElement("Value")]
        public string Value { get; set; } = null!;
    }
} 