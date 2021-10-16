using AutoMapper;
using MediatR;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands.Like.Create
{
    public class CreateLikeWithValidateOnExistCommandHandler : IRequestHandler<CreateLikeWithValidateOnExistCommand, bool>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public CreateLikeWithValidateOnExistCommandHandler(ILikeRepository likeRepository,IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateLikeWithValidateOnExistCommand request, CancellationToken cancellationToken)
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
            await _likeRepository.SaveAsync();
            return false;
        }
    }
}
