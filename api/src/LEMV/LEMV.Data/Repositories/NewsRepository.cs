using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using LiteDB;
using MongoDB.Driver;

namespace LEMV.Data.Repositories
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        private const string COLLECTION_NAME = "news";

        public NewsRepository(IMongoClient db) : base(db)
        {
            DefineCollection(COLLECTION_NAME);
        }
    }
}