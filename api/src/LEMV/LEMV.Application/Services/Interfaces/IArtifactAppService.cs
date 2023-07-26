using LEMV.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LEMV.Domain.Interfaces
{
    public interface IArtifactAppService
    {
        ArtifactViewModel CreateArtifact(ArtifactSaveViewModel artifact);
        ArtifactViewModel UpdateArtifact(ArtifactSaveViewModel artifact);
        ICollection<ArtifactViewModel> GetAll();
        ArtifactViewModel GetById(string id);
        void DeleteArtifact(string id);
    }
}
