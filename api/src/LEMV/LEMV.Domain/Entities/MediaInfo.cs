using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LEMV.Domain.Entities
{
    public class MediaInfo : Entity
    {
        public string FileName { get; set; }
        public string Format { get; set; }
        public double Size { get; set; } //In Megabytes

        public MediaInfo()
        {

        }

        public MediaInfo(string id, string fileName, string format, double sizeMegabytes)
        {
            Id = id;
            FileName = fileName;
            Format = format;
            Size = sizeMegabytes;
        }

        internal static MediaInfo FromBsonDocument(BsonDocument asBsonDocument)
        {
            throw new NotImplementedException();
        }
    }
}
