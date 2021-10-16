using AutoMapper;
using MediatR;
using PoemPost.Data.DTO;
using PoemPost.Data.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.Host.Queries
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, List<AuthorDTO>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public GetAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<List<AuthorDTO>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authorsEntities = await _authorRepository.GetAllAsync(request.TrackChanges);
            return _mapper.Map<List<AuthorDTO>>(authorsEntities);
        }
    }
}
