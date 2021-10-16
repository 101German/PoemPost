using AutoMapper;
using PoemPost.Data.DataTransferObjects;
using PoemPost.Data.Models;
using System;

namespace PoemPost.Data.Mapping
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentForCreationDTO, Comment>().ForMember(x => x.CreationDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Comment, CommentDTO>().ForMember(c => c.AuthorName, opt => opt.MapFrom(x => x.Author.Name));
        }
    }
}
