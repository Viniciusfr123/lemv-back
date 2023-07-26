using LEMV.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LEMV.Application.Services.Interfaces
{
    public interface IProjectAppService
    {
        ProjectViewModel CreateProject(ProjectSaveViewModel news);
        ProjectViewModel UpdateProject(ProjectSaveViewModel news);
        ICollection<ProjectViewModel> GetAll();
        ProjectViewModel GetById(string id);
        void DeleteProject(string id);
    }
}
