using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LEMV.Domain.Entities
{
    public class Artifact : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Resume { get; set; }
        public virtual string Description { get; set; }

        public virtual List<string> UrlImages { get; set; }

        public virtual MediaInfo Media { get; set; }

        public virtual string SkillId { get; set; }
        public virtual ICollection<string> AbilitieIds { get; set; }

        public List<string> Tags { get; set; }

        public Artifact()
        {

        }

        public Artifact(string id, string name, string description, List<string> tags, string resume, List<string> urlImages)
        {
            Id = id;
            Name = name;
            UrlImages = urlImages;
            Description = description;
            Tags = tags;
            Resume = resume;

        }
    }
}
