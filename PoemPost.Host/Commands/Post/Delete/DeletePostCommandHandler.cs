using MediatR;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.Host.Commands.Delete
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand,bool>
    {
        private readonly IPostRepository _postRepository;

        public DeletePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var postEntity =await  _postRepository.GetByIdAsync(request.Id, trackChanges: true);
            if (postEntity == null)
            {
                return false;
            }

            _postRepository.Delete(postEntity);
            await   _postRepository.SaveAsync();

            return true;

        }
    }
}
