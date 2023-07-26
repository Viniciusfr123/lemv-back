using LEMV.Application.ViewModels;
using System.Threading.Tasks;

namespace LEMV.Domain.Interfaces
{
    public interface IMaterialAppService
    {
        MaterialViewModel CreateMaterial(MaterialViewModel news);
        MaterialViewModel UpdateMaterial(MaterialViewModel news);
        void DeleteMaterial(string id);
    }
}
