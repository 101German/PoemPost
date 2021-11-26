using AutoMapper;
using MediatR;
using PoemPost.Data.Interfaces;
using PoemPost.Data.UserContext;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands.Like.Create
{
    public class CreateLikeWithExistenceCheckCommandHandler : IRequestHandler<CreateLikeWithExistenceCheckCommand, bool>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateLikeWithExistenceCheckCommandHandler(ILikeRepository likeRepository,IMapper mapper,IUserContext userContext)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<bool> Handle(CreateLikeWithExistenceCheckCommand request, CancellationToken cancellationToken)
        {
            request.Like.UserId = _userContext.UserId;
            var like = await _likeRepository.GetAsync(request.Like.PostId, request.Like.UserId);

            if (like == null)
            {
                _likeRepository.Add(_mapper.Map<Data.Models.Like>(request.Like));
                await _likeRepository.SaveAsync();

                return true;
            }

            _likeRepository.Remove(like);
            await _likeRepository.SaveAsync();

            return false;
        }
    }
}
