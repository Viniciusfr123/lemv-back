using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LEMV.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        protected string _collection;

        protected MongoClient _db;
        protected IMongoCollection<TEntity> _dbSet;

        protected Repository(IMongoClient dbContext)
        {
            _db = (MongoClient)dbContext;
        }

        protected void DefineCollection(string collectionName)
        {
            _collection = collectionName;
            _dbSet = _db.GetDatabase("lemv").GetCollection<TEntity>(_collection);
        }

        public virtual TEntity Add(TEntity entity)
        {
             _dbSet.InsertOne(entity);
            return entity;
        }

        public virtual void Delete(string id)
        {
            _dbSet.DeleteOne(x => x.Id == id);
        }

        public virtual ICollection<TEntity> GetAll()
        {
            return _dbSet.Find(book => true).ToList();
        }

        public virtual TEntity GetById(string id)
        {
            return _dbSet.Find<TEntity>(x => x.Id == id).FirstOrDefault();
        }

        public virtual TEntity Update(TEntity entity)
        {
            _dbSet.ReplaceOne(x => x.Id == entity.Id, entity);

            return GetById(entity.Id);
        }
    }
}