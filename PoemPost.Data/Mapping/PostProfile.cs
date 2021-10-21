using AutoMapper;
using PoemPost.Data.DTO;
using PoemPost.Data.Models;
using System;

namespace PoemPost.Data.Mapping
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostForCreationDTO, Post>()
                .ForMember(p => p.CreationDate, opt => opt
                .MapFrom(p => DateTime.Now));

            CreateMap<Post, PostDTO>()
                .ForMember(p => p.LikesCount, opt => opt
                .MapFrom(p => p.Likes.Count)) 
                .ForMember(p => p.AuthorName, opt => opt
                .MapFrom(p => p.Author.Name));

            CreateMap<PostForUpdateDTO, Post>()
                .ForMember(p => p.LastUpdateDate, opt => opt
                .MapFrom(p => DateTime.Now));

            CreateMap<PostForCreationDTO, PostDTO>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.AuthorId, opt => opt.Ignore())
                .ForMember(p => p.Comments, opt => opt.Ignore())
                .ForMember(p => p.CreationDate, opt => opt.Ignore())
                .ForMember(p => p.LikesCount, opt => opt.Ignore());
                
        }
    }
}
