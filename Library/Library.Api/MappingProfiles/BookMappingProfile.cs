using AutoMapper;
using Library.Api.DTOs;
using Library.Domain.Entities;

namespace Library.Api.MappingProfiles
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<BookDto, Book>();
        }
    }
}
