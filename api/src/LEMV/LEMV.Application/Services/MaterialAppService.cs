using AutoMapper;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using System.Threading.Tasks;

namespace LEMV.Application.Services
{
    public class MaterialAppService : IMaterialAppService
    {
        private readonly IMapper _mapper;
        private readonly IMaterialService _service;

        public MaterialAppService(IMapper mapper, IMaterialService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public MaterialViewModel CreateMaterial(MaterialViewModel material)
        {
            var entity = _mapper.Map<Material>(material);

            entity = _service.Create(entity);

            return _mapper.Map<MaterialViewModel>(entity);
        }

        public MaterialViewModel UpdateMaterial(MaterialViewModel material)
        {
            var entity = _mapper.Map<Material>(material);

            entity = _service.Update(entity);

            return _mapper.Map<MaterialViewModel>(entity);
        }

        public void DeleteMaterial(string id)
        {
            _service.Delete(id);
        }
    }
}