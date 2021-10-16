using AutoMapper;
using MediatR;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands.Update
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var postEntity = await _postRepository.GetByIdAsync(request.Id, trackChanges: true);
            if (postEntity == null)
            {
                return false;
            }

            _mapper.Map(request.Post, postEntity);
           

            await _postRepository.SaveAsync();

            return true;
        }
    }
}
