using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class OutboundClaimFile : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; } = null!;
        [BsonElement("SubmissionDate")]
        public DateTime SubmissionDate { get; set; }
        [BsonElement("SubmitterID")]
        public string SubmitterID { get; set; } = null!;
        [BsonElement("ReceiverID")]
        public string ReceiverID { get; set; } = null!;
        [BsonElement("InterchangeCtrlNo")]
        public string InterchangeCtrlNo { get; set; } = null!;
        [BsonElement("NoOfClaims")]
        public int NoOfClaims { get; set; }
    }
} 