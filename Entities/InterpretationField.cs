using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace PemrClearingHouse.Api.Entities
{
    [BsonIgnoreExtraElements]
    public class InterpretationField : BaseEntity
    {
        [ForeignKey("InterpretationEntityID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InterpretationEntityID { get; set; } = null!;
        [BsonIgnore]
        public InterpretationEntity? InterpretationEntity { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; } = null!;
        [BsonElement("Code")]
        public string Code { get; set; } = null!;
    }
} 