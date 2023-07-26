using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;

namespace LEMV.Domain.Services
{
    public class BookService : BaseService<Book>, IBookService
    {
        public BookService(INotificator notificator, IBookRepository bookRepository) : base(notificator, bookRepository) { }
    }
}
