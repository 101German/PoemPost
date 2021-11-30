using AutoMapper;
using MediatR;
using PoemPost.Data.DTO;
using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;
using System.Threading;
using System.Threading.Tasks;
using PoemPost.Data.UserContext;

namespace PoemPost.App.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, PostDTO>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        private readonly IMediator _mediator;

        public CreatePostCommandHandler(
            IPostRepository postRepository,
            IMapper mapper,
            IUserContext userContext,
            IMediator mediator)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _userContext = userContext;
            _mediator = mediator;
        }

        public async Task<PostDTO> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            if (_userContext.AuthorId == 0)
            {
                var author = await _mediator.Send(new CreateAuthorCommand()
                {
                    Author = new AuthorForCreationDTO()
                    {
                        UserId = _userContext.UserId,
                        Name = _userContext.Name,
                        AuthorType = AuthorType.Contemporary,
                    }
                }, cancellationToken);
                request.Post.AuthorId = author.Id;
                request.Post.AuthorName = author.Name;
            }
            else
            {
                request.Post.AuthorId = _userContext.AuthorId;
                request.Post.AuthorName = _userContext.Name;
            }

            var postEntity = _mapper.Map<Post>(request.Post);
            _postRepository.Insert(postEntity);
            await _postRepository.SaveAsync();

            var postForReturn = _mapper.Map<PostDTO>(postEntity);
            postForReturn = _mapper.Map(request.Post, postForReturn);

            return postForReturn;
        }
    }
}
