using System;
using LEMV.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LEMV.Domain.Entities
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastMofication { get; set; }

        public Entity()
        {
            CreatedAt = DateTime.Now;
        }

    }
}