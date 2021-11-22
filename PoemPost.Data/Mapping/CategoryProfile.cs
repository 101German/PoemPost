using AutoMapper;
using PoemPost.Data.DTO.Category;
using PoemPost.Data.Models;

namespace PoemPost.Data.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryForCreationDTO, Category>();
        }
    }
}
