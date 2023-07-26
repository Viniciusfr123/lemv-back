using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;

namespace LEMV.Domain.Services
{
    public class NewsService : BaseService<News>, INewsService
    {
        public NewsService(INotificator notificator, INewsRepository newsRepository) : base(notificator, newsRepository) { }

    }
}