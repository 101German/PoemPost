using AutoMapper;
using MediatR;
using PoemPost.Data.DTO;
using PoemPost.Data.Interfaces;
using PoemPost.Data.RequestFeauters;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Queries
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, PagedList<AuthorDTO>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public GetAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<PagedList<AuthorDTO>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authorsEntities = await _authorRepository.GetAuthors(request.AuthorParameters,request.TrackChanges);
            return _mapper.Map<PagedList<AuthorDTO>>(authorsEntities);
        }
    }
}
