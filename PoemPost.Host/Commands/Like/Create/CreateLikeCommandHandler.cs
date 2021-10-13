using AutoMapper;
using MediatR;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.Host.Commands.Like.Create
{
    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, bool>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public CreateLikeCommandHandler(ILikeRepository likeRepository,IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            var like = await _likeRepository.GetAsync(request.Like.PostId, request.Like.AuthorId);
            if (like == null)
            {
                _mapper.Map(request.Like, like);
                _likeRepository.Add(like);
                await _likeRepository.SaveAsync();
                return true;
            }

            _likeRepository.Remove(like);
            return false;
        }
    }
}
