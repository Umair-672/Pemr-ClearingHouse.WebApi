using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class InboundClaimFile : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; } = null!;
        [BsonElement("ReceivedDate")]
        public DateTime ReceivedDate { get; set; }
        [BsonElement("SubmitterID")]
        public string SubmitterID { get; set; } = null!;
        [BsonElement("ReceiverID")]
        public string ReceiverID { get; set; } = null!;
        [BsonElement("SiteID")]
        public string SiteID { get; set; } = null!;
        [BsonElement("InterchangeCtrlNo")]
        public string InterchangeCtrlNo { get; set; } = null!;
        [BsonElement("NoOfClaims")]
        public int NoOfClaims { get; set; }
    }
} 