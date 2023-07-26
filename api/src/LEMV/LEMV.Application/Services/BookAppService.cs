using AutoMapper;
using LEMV.Application.ViewModels;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using System.Threading.Tasks;

namespace LEMV.Application.Services
{
    public class BookAppService : IBookAppService
    {
        private readonly IMapper _mapper;
        private readonly IBookService _service;

        public BookAppService(IMapper mapper, IBookService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public BookViewModel CreateBook(BookViewModel book)
        {
            var entity = _mapper.Map<Book>(book);

            entity = _service.Create(entity);

            return _mapper.Map<BookViewModel>(entity);
        }

        public BookViewModel UpdateBook(BookViewModel book)
        {
            var entity = _mapper.Map<Book>(book);

            entity = _service.Update(entity);

            return _mapper.Map<BookViewModel>(entity);
        }

        public void DeleteBook(string id)
        {
            _service.Delete(id);
        }
    }
}