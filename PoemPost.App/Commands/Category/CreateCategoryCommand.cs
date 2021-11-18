using MediatR;
using PoemPost.Data.DTO.Category;

namespace PoemPost.App.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryDTO>
    {
        public CategoryForCreationDTO Category { get; set; }
    }
}
