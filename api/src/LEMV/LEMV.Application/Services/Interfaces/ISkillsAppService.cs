using LEMV.Application.ViewModels;
using System.Threading.Tasks;

namespace LEMV.Application.Services.Interfaces
{
    public interface ISkillsAppService
    {
        SkillViewModel CreateSkill(SkillViewModel news);
        SkillViewModel UpdateSkill(SkillViewModel news);
        void DeleteSkill(string id);
    }
}
