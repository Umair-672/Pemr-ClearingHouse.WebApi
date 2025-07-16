using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class TransactionRoute : BaseEntity
    {
        [ForeignKey("InsuranceCarrierID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InsuranceCarrierID { get; set; } = null!;
        [BsonIgnore]
        public InsuranceCarrier? InsuranceCarrier { get; set; }
        [ForeignKey("X12TransactionID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string X12TransactionID { get; set; } = null!;
        [BsonIgnore]
        public X12Transaction? X12Transaction { get; set; }
        [ForeignKey("GatewayID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string GatewayID { get; set; } = null!;
        [BsonIgnore]
        public Gateway? Gateway { get; set; }
        [BsonElement("AuthInfo")]
        public string AuthInfo { get; set; } = null!;
        [BsonElement("SecurityInfo")]
        public string SecurityInfo { get; set; } = null!;
        [BsonElement("SubmitterQualifier")]
        public string SubmitterQualifier { get; set; } = null!;
        [BsonElement("SubmitterID")]
        public string SubmitterID { get; set; } = null!;
        [BsonElement("ReceiverQualifier")]
        public string ReceiverQualifier { get; set; } = null!;
        [BsonElement("ReceiverID")]
        public string ReceiverID { get; set; } = null!;
        [BsonElement("SenderCode")]
        public string SenderCode { get; set; } = null!;
        [BsonElement("ReceiverCode")]
        public string ReceiverCode { get; set; } = null!;
        [BsonElement("ReceiverName")]
        public string ReceiverName { get; set; } = null!;
        [BsonElement("ReceiverPrimaryIdentifier")]
        public string ReceiverPrimaryIdentifier { get; set; } = null!;
        [BsonElement("OutboundPayerID")]
        public string OutboundPayerID { get; set; } = null!;
        [BsonElement("InboundPayerID")]
        public string InboundPayerID { get; set; } = null!;
        [BsonElement("ConnectionMode")]
        public string ConnectionMode { get; set; } = null!;
        [BsonElement("IsPreferred")]
        public bool IsPreferred { get; set; }
    }
} 