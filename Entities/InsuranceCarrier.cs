using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class InsuranceCarrier : BaseEntity
    {
        [ForeignKey("InsuranceID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InsuranceID { get; set; } = null!;
        [BsonIgnore]
        public Insurance? Insurance { get; set; }
        [ForeignKey("DialupSettingID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DialupSettingID { get; set; } = null!;
        [BsonIgnore]
        public DialupSettings? DialupSetting { get; set; }
        [BsonElement("DisplayName")]
        public string DisplayName { get; set; } = null!;
        [BsonElement("Address1")]
        public string Address1 { get; set; } = null!;
        [BsonElement("Address2")]
        public string Address2 { get; set; } = null!;
        [BsonElement("State")]
        public string State { get; set; } = null!;
        [BsonElement("City")]
        public string City { get; set; } = null!;
        [BsonElement("ZipCode")]
        public string ZipCode { get; set; } = null!;
        [BsonElement("Phone")]
        public string Phone { get; set; } = null!;
        [BsonElement("Fax")]
        public string Fax { get; set; } = null!;
        [BsonElement("Email")]
        public string Email { get; set; } = null!;
        [BsonElement("URL")]
        public string URL { get; set; } = null!;
        [BsonElement("AcceptSecondaryClaim")]
        public bool AcceptSecondaryClaim { get; set; }
        [BsonElement("AcceptCorrectedClaim")]
        public bool AcceptCorrectedClaim { get; set; }
        [BsonElement("ClaimFilingLimit")]
        public int ClaimFilingLimit { get; set; }
        [BsonElement("AppealFilingLimit")]
        public int AppealFilingLimit { get; set; }
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
        [BsonElement("IsDeleted")]
        public bool IsDeleted { get; set; }
    }
} 