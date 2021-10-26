using AutoMapper;
using MediatR;
using PoemPost.Data.DTO;
using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorDTO>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDTO> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorEntity = _mapper.Map<Author>(request.Author);
            _authorRepository.Insert(authorEntity);
            await _authorRepository.SaveAsync();

            return _mapper.Map<AuthorDTO>(authorEntity);
        }
    }
}
