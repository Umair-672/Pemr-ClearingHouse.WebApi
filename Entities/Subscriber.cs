using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class Subscriber : BaseEntity
    {
        [ForeignKey("BillingProviderID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BillingProviderID { get; set; } = null!;
        [BsonIgnore]
        public BillingProvider? BillingProvider { get; set; }
        [BsonElement("FirstName")]
        public string FirstName { get; set; } = null!;
        [BsonElement("LastName")]
        public string LastName { get; set; } = null!;
        [BsonElement("MiddleName")]
        public string MiddleName { get; set; } = null!;
        [BsonElement("PrimaryIdentification")]
        public string PrimaryIdentification { get; set; } = null!;
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
        [BsonElement("SecondaryIdentification")]
        public string SecondaryIdentification { get; set; } = null!;
        [BsonElement("PayerResponsibility")]
        public string PayerResponsibility { get; set; } = null!;
        [BsonElement("RelationshipCode")]
        public string RelationshipCode { get; set; } = null!;
        [BsonElement("InsuranceTypeCode")]
        public string InsuranceTypeCode { get; set; } = null!;
        [BsonElement("ClaimFilingIndicator")]
        public string ClaimFilingIndicator { get; set; } = null!;
        [BsonElement("Gender")]
        public string Gender { get; set; } = null!;
        [BsonElement("DOB")]
        public DateTime DOB { get; set; }
    }
} 