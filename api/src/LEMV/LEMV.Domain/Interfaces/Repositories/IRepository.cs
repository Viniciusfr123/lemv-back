using LEMV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LEMV.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        ICollection<TEntity> GetAll();
        TEntity GetById(string id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(string id);
    }
}
