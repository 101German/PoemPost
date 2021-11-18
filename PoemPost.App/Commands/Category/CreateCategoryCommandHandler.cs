using AutoMapper;
using MediatR;
using PoemPost.Data.DTO.Category;
using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDTO>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryDTO> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryEntity = _mapper.Map<Category>(request.Category);
            _categoryRepository.Insert(categoryEntity);
            await _categoryRepository.SaveAsync();

            return _mapper.Map<CategoryDTO>(categoryEntity);
        }
    }
}
