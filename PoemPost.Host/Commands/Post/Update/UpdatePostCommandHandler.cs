using AutoMapper;
using MediatR;
using System;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.Host.Commands.Update
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
            postEntity.LastUpdateDate = DateTime.Now;

            await _postRepository.SaveAsync();

            return true;
        }
    }
}
