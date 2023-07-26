using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using LiteDB;
using MongoDB.Driver;

namespace LEMV.Data.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        private const string COLLECTION_NAME = "materials";

        public MaterialRepository(IMongoClient db) : base(db)
        {
            DefineCollection(COLLECTION_NAME);
        }
    }
}