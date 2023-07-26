using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;

namespace LEMV.Domain.Services
{
    public class MaterialService : BaseService<Material>, IMaterialService
    {

        public MaterialService(INotificator notificator, IMaterialRepository materialRepository) : base(notificator, materialRepository) { }
    }
}
