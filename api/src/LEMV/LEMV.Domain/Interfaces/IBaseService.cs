using LEMV.Domain.Entities;
using System.Threading.Tasks;

namespace LEMV.Domain.Interfaces
{
    public interface IBaseService<T> where T : Entity
    {
        T Create(T entity);

        T Update(T entity);

        void Delete(string id);
    }
}
