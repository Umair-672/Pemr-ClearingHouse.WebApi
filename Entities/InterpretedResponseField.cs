using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class InterpretedResponseField : BaseEntity
    {
        [ForeignKey("InterpretedResponseID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InterpretedResponseID { get; set; } = null!;
        [BsonIgnore]
        public InterpretedResponse? InterpretedResponse { get; set; }
        [ForeignKey("InterpretationFieldID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InterpretationFieldID { get; set; } = null!;
        [BsonIgnore]
        public InterpretationField? InterpretationField { get; set; }
    }
} 