using LEMV.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LEMV.Application.Services.Interfaces
{
    public interface INewsAppService
    {
        NewsViewModel CreateNews(NewsSaveViewModel news);
        NewsViewModel UpdateNews(NewsSaveViewModel news);
        ICollection<NewsViewModel> GetAll();
        NewsViewModel GetById(string id);
        void DeleteNews(string id);
    }
}
