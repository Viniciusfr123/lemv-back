using LEMV.Application.ViewModels;
using System.Threading.Tasks;

namespace LEMV.Domain.Interfaces
{
    public interface IBookAppService
    {
        BookViewModel CreateBook(BookViewModel news);
        BookViewModel UpdateBook(BookViewModel news);
        void DeleteBook(string id);
    }
}
