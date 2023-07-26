using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LEMV.Domain.Entities
{
    public class Ability
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;

        public Ability()
        {

        }

        public Ability(string id, string code, string description)
        {
            Id = id;
            Code = code;
            Description = description;
        }
    }
}
