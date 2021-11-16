using AutoMapper;
using PoemPost.Data.DTO;
using PoemPost.Data.Models;
using PoemPost.Data.RequestFeauters;

namespace PoemPost.Data.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorForCreationDTO, Author>();

            CreateMap<Author, AuthorDTO>()
                .ForMember(a=>a.PostsCount,opt=>opt
                .MapFrom(a=>a.Posts.Count));
            CreateMap<AuthorForUpdateDTO, Author>();

            CreateMap<PagedList<Author>, PagedList<AuthorDTO>>()
              .ForMember(a => a.MetaData, opt => opt
              .MapFrom(a => a.MetaData))
              .ForMember(a => a.Items, opt => opt.MapFrom(a => a.Items));
        }
       
    }
}
