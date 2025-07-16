using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class InboundTransaction : BaseEntity
    {
        [ForeignKey("InboundClaimFileID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InboundClaimFileID { get; set; } = null!;
        [BsonIgnore]
        public InboundClaimFile? InboundClaimFile { get; set; }
        [BsonElement("CtrlNo")]
        public string CtrlNo { get; set; } = null!;
        [BsonElement("VersionName")]
        public string VersionName { get; set; } = null!;
        [BsonElement("SubmitterEntityType")]
        public string SubmitterEntityType { get; set; } = null!;
        [BsonElement("SubmitterFirstName")]
        public string SubmitterFirstName { get; set; } = null!;
        [BsonElement("SubmitterLastName")]
        public string SubmitterLastName { get; set; } = null!;
        [BsonElement("SubmitterIdentificationCode")]
        public string SubmitterIdentificationCode { get; set; } = null!;
        [BsonElement("SubmitterContactName")]
        public string SubmitterContactName { get; set; } = null!;
        [BsonElement("SubmitterPhoneNo")]
        public string SubmitterPhoneNo { get; set; } = null!;
        [BsonElement("SubmitterFaxNo")]
        public string SubmitterFaxNo { get; set; } = null!;
        [BsonElement("SubmitterEmail")]
        public string SubmitterEmail { get; set; } = null!;
    }
} 