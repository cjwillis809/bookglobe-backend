using AutoMapper;
using bookglobe_backend.Controllers.Dtos;
using bookglobe_backend.Models;

namespace bookglobe_backend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>();

            CreateMap<BookDto, Book>().ForMember(br => br.Id, opt => opt.Ignore());
        }
    }
}