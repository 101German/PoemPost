using MediatR;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands.Delete
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var commentEntity = await _commentRepository.GetByIdAsync(request.Id, trackChanges: true);

            _commentRepository.Delete(commentEntity);
            await _commentRepository.SaveAsync();

            return Unit.Value;
        }
    }
}
