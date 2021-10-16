using AutoMapper;
using PoemPost.Data.DTO;
using PoemPost.Data.Models;
using System;

namespace PoemPost.Data.Mapping
{
    public class PostProfile:Profile
    {
        public PostProfile()
        {
            CreateMap<PostForCreationDTO, Post>().ForMember(x => x.CreationDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Post, PostDTO>().ForMember(p => p.LikesCount, opt => opt.MapFrom(x => x.Likes.Count));
            CreateMap<PostForUpdateDTO, Post>().ForMember(x => x.LastUpdateDate, opt => opt.MapFrom(x => DateTime.Now)); ;
        }
    }
}
