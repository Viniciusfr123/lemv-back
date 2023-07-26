using LiteDB;
using System.Collections.Generic;

namespace LEMV.Domain.Entities
{
    public class Skill : Entity
    {
        public string Code { get; set; }
        public string Description { get; set; }

        [BsonRef("abilities")]
        public ICollection<Ability> Abilities { get; set; }

        public Skill()
        {

        }

        public Skill(string id,
                     string code,
                     string description,
                     ICollection<Ability> abilities)
        {
            Id = id;
            Code = code;
            Description = description;
            Abilities = abilities;
        }
    }
}
