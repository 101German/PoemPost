using AutoMapper;
using MediatR;
using PoemPost.Data.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.Host.Commands
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly AuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(AuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorEntity = await _authorRepository.GetByIdAsync(request.Id, trackChanges: true);

            if (authorEntity == null)
            {
                return false;
            }

            _mapper.Map(request.Author, authorEntity);

            await _authorRepository.SaveAsync();

            return true;
        }
    }
}
