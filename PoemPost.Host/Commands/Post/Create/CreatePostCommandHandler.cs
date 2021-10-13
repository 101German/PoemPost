using AutoMapper;
using System;
using MediatR;
using PoemPost.Data.DataTransferObjects;
using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.Host.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, PostDTO>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostDTO> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var postEntity = _mapper.Map<Post>(request.Post);
            postEntity.CreationDate = DateTime.Now;
            postEntity.AuthorId = request.AuthorId;

            _postRepository.Insert(postEntity);
            await _postRepository.SaveAsync();

            return _mapper.Map<PostDTO>(postEntity);

        }
    }
}
