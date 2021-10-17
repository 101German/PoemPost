using MediatR;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands.Delete
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IPostRepository _postRepository;

        public DeletePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var postEntity =await  _postRepository.GetByIdAsync(request.Id, trackChanges: true);

            _postRepository.Delete(postEntity);
            await   _postRepository.SaveAsync();

            return Unit.Value;

        }
    }
}
