using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class OutboundTransaction : BaseEntity
    {
        [ForeignKey("OutboundClaimFileID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OutboundClaimFileID { get; set; } = null!;
        [BsonIgnore]
        public OutboundClaimFile? OutboundClaimFile { get; set; }
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
        [BsonElement("SubmitterIdentification")]
        public string SubmitterIdentification { get; set; } = null!;
    }
} 