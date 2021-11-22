using MediatR;
using Microsoft.AspNetCore.Mvc;
using PoemPost.App.Commands;
using PoemPost.App.Queries;
using PoemPost.App.Queries.Category;
using PoemPost.Data.DTO.Category;
using System.Threading.Tasks;

namespace PoemPost.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryForCreationDTO category)
        {
            var categoryForReturn = await _mediator.Send(new CreateCategoryCommand()
            {
                Category = category
            });

            return Ok(categoryForReturn);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categoriesDTO = await _mediator.Send(new GetAllCategoriesQuery());

            return Ok(categoriesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var categoryDTO = await _mediator.Send(new GetCategoryByIdQuery()
            {
                Id = id
            });

            return Ok(categoryDTO);
        }
    }
}
