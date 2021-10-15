using MediatR;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.Host.Commands
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly IAuthorRepository _authorRepository;
        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorEntity = await _authorRepository.GetByIdAsync(request.Id, trackChanges: true);

            if (authorEntity == null)
            {
                return false;
            }

            _authorRepository.Delete(authorEntity);
            await _authorRepository.SaveAsync();
            return true;

        }
    }
}
