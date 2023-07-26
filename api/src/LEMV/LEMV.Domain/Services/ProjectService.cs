using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;

namespace LEMV.Domain.Services
{
    public class ProjectService : BaseService<Project>, IProjectService
    {
        public ProjectService(INotificator notificator, IProjectRepository projectRepository) : base(notificator, projectRepository) { }
    }
}
