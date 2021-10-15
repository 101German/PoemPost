using AutoMapper;
using PoemPost.Data.DataTransferObjects;
using PoemPost.Data.DataTransferObjects.Like;
using PoemPost.Data.Models;
using System;

namespace PoemPost.Data.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorForCreationDTO, Author>();
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorForUpdateDTO, Author>();

            CreateMap<PostForCreationDTO, Post>().ForMember(x => x.CreationDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Post, PostDTO>().ForMember(p => p.LikesCount, opt => opt.MapFrom(x => x.Likes.Count));
            CreateMap<PostForUpdateDTO, Post>();

            CreateMap<CommentForCreationDTO, Comment>().ForMember(x => x.CreationDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Comment, CommentDTO>().ForMember(c => c.AuthorName, opt => opt.MapFrom(x => x.Author.Name));

            CreateMap<LikeForCreationDTO, Like>();
        }
    }
}
