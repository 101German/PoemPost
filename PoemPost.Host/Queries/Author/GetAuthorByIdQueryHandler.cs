using AutoMapper;
using MediatR;
using PoemPost.Data.DataTransferObjects;
using PoemPost.Data.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.Host.Queries
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDTO>
    {
        private readonly AuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(AuthorRepository authorRepository,IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<AuthorDTO> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var authorEntity = await _authorRepository.GetByIdAsync(request.Id, request.TrackChanges);
            return _mapper.Map<AuthorDTO>(authorEntity);
        }
    }
}
