using AutoMapper;
using PoemPost.Data.DTO;
using PoemPost.Data.Models;
using System;

namespace PoemPost.Data.Mapping
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentForCreationDTO, Comment>()
                .ForMember(x => x.CreationDate,
                opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}
