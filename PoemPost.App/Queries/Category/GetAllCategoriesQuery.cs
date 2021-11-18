using MediatR;
using PoemPost.Data.DTO.Category;
using System.Collections.Generic;

namespace PoemPost.App.Queries.Category
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryDTO>>
    {
    }
}
