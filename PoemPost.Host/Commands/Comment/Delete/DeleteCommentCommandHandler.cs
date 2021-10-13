using MediatR;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.Host.Commands.Delete
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, bool>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var commentEntity = await _commentRepository.GetByIdAsync(request.Id, trackChanges: true);

            if (commentEntity == null)
            {
                return false;
            }

            _commentRepository.Delete(commentEntity);
            await _commentRepository.SaveAsync();

            return true;
        }
    }
}
