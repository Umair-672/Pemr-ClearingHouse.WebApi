using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class BillingProvider : BaseEntity
    {
        [ForeignKey("InsuranceCarrierID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InboundTransactionID { get; set; } = null!;
        [BsonIgnore]
        public InboundTransaction? InboundTransaction { get; set; }
        [BsonElement("EntityTypeQualifier")]
        public string EntityTypeQualifier { get; set; } = null!;
        [BsonElement("FirstName")]
        public string FirstName { get; set; } = null!;
        [BsonElement("LastName")]
        public string LastName { get; set; } = null!;
        [BsonElement("MiddleName")]
        public string MiddleName { get; set; } = null!;
        [BsonElement("NPI")]
        public string NPI { get; set; } = null!;
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
        [BsonElement("TaxonomyCode")]
        public string TaxonomyCode { get; set; } = null!;
    }
} 