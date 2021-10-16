using AutoMapper;
using PoemPost.Data.DataTransferObjects;
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
