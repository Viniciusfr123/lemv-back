using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using LiteDB;
using MongoDB.Driver;

namespace LEMV.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private const string COLLECTION_NAME = "books";

        public BookRepository(IMongoClient db) : base(db)
        {
            DefineCollection(COLLECTION_NAME);
        }
    }
}