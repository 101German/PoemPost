using AutoMapper;
using MediatR;
using PoemPost.Data.DTO.Category;
using PoemPost.Data.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Queries.Category
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<CategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categoriesEntities = await _categoryRepository.GetAllAsync(trackChanges: false);

            return _mapper.Map<List<CategoryDTO>>(categoriesEntities);
        }
    }
}
