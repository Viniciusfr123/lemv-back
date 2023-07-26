using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace LEMV.Data.Repositories
{
    public class SkillsRepository : Repository<Skill>, ISkillsRepository
    {
        private const string COLLECTION_NAME = "skills";

        public SkillsRepository(IMongoClient db) : base(db)
        {
            DefineCollection(COLLECTION_NAME);
        }
        public override Skill Add(Skill entity)
        {
            foreach (var ability in entity.Abilities)
            {
                ability.Id = ObjectId.GenerateNewId().ToString();
            }
            _dbSet.InsertOne(entity);
            return entity;
        }
    }
}