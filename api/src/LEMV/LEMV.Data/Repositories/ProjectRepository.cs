using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace LEMV.Data.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private const string COLLECTION_NAME = "projects";

        public ProjectRepository(IMongoClient db) : base(db)
        {
            DefineCollection(COLLECTION_NAME);

        }
        public override Project Add(Project entity)
        {
            foreach (var step in entity.Manual)
            {
                step.Id = ObjectId.GenerateNewId().ToString();
            }
            _dbSet.InsertOne(entity);
            return entity;
        }

    }
}