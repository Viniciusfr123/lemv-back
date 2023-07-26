using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;

namespace LEMV.Domain.Services
{
    public class SkillsService : BaseService<Skill>, ISkillsService
    {
        public SkillsService(INotificator notificator, ISkillsRepository skillsRepository) : base(notificator, skillsRepository) { }
    }
}
