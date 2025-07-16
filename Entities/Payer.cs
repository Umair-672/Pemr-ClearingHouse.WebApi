using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class Payer : BaseEntity
    {
        [ForeignKey("SubscriberID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SubscriberID { get; set; } = null!;
        [BsonIgnore]
        public Subscriber? Subscriber { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; } = null!;
        [BsonElement("IdentificationCode")]
        public string IdentificationCode { get; set; } = null!;
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
    }
} 