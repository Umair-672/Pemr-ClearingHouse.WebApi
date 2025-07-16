using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class Claim : BaseEntity
    {
        [ForeignKey("SubscriberID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SubscriberID { get; set; } = null!;
        [BsonIgnore]
        public Subscriber? Subscriber { get; set; }
        [BsonElement("PatientControlNumber")]
        public string PatientControlNumber { get; set; } = null!;
        [BsonElement("ChargeAmount")]
        public decimal ChargeAmount { get; set; }
        [BsonElement("PlaceOfService")]
        public string PlaceOfService { get; set; } = null!;
        [BsonElement("DateOfService")]
        public DateTime DateOfService { get; set; }
        [BsonElement("ReferralNo")]
        public string ReferralNo { get; set; } = null!;
        [BsonElement("PriorAuthorization")]
        public string PriorAuthorization { get; set; } = null!;
        [BsonElement("PayerControlNumber")]
        public string PayerControlNumber { get; set; } = null!;
    }
} 