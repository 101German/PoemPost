using AutoMapper;
using PoemPost.Data.DTO.Like;
using PoemPost.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.Data.Mapping
{
    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            CreateMap<LikeForCreationDTO, Like>();
        }
    }
}
