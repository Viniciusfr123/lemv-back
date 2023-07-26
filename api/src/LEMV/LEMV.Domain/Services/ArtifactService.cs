using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;

namespace LEMV.Domain.Services
{
    public class ArtifactService : BaseService<Artifact>, IArtifactService
    {
        public ArtifactService(INotificator notificator, IArtifactRepository artifactRepository) : base(notificator, artifactRepository) { }
    }
}
