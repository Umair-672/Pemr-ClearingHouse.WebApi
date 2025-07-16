using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class RTTransactionSettings : BaseEntity
    {
        [ForeignKey("TransactionRouteID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TransactionRouteID { get; set; } = null!;
        [BsonIgnore]
        public TransactionRoute? TransactionRoute { get; set; }
        [BsonElement("URI")]
        public string URI { get; set; } = null!;
        [BsonElement("UserName")]
        public string UserName { get; set; } = null!;
        [BsonElement("Password")]
        public string Password { get; set; } = null!;
    }
} 