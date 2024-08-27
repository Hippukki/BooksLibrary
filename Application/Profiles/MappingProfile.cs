using Application.DTOs.Author;
using Application.DTOs.Book;
using Application.DTOs.Publisher;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDTO>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
            .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher));

        CreateMap<BookDTO, Book>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
            .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher));

        CreateMap<Author, AuthorDTO>().ReverseMap();

        CreateMap<Publisher, PublisherDTO>().ReverseMap();
    }
}
