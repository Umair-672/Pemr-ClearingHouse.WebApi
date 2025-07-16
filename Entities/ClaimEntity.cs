using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class ClaimEntity : BaseEntity
    {
        [ForeignKey("ClaimID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClaimID { get; set; } = null!;
        [BsonIgnore]
        public Claim? Claim { get; set; }
        [BsonElement("EntityCode")]
        public string EntityCode { get; set; } = null!;
        [BsonElement("EntityTypeQualifier")]
        public string EntityTypeQualifier { get; set; } = null!;
        [BsonElement("FirstName")]
        public string FirstName { get; set; } = null!;
        [BsonElement("LastName")]
        public string LastName { get; set; } = null!;
        [BsonElement("MiddleName")]
        public string MiddleName { get; set; } = null!;
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
        [BsonElement("PrimaryIdentification")]
        public string PrimaryIdentification { get; set; } = null!;
        [BsonElement("SecondaryIdentification")]
        public string SecondaryIdentification { get; set; } = null!;
        [BsonElement("TaxonomyCode")]
        public string TaxonomyCode { get; set; } = null!;
    }
} 