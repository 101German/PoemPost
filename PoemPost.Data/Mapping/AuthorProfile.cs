using AutoMapper;
using PoemPost.Data.DTO;
using PoemPost.Data.Models;

namespace PoemPost.Data.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorForCreationDTO, Author>();
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorForUpdateDTO, Author>();
        }
       
    }
}
