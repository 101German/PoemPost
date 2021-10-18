using AutoMapper;
using MediatR;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Commands.Like.Create
{
    public class CreateLikeWithExistenceCheckCommandHandler : IRequestHandler<CreateLikeWithExistenceCheckCommand, bool>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public CreateLikeWithExistenceCheckCommandHandler(ILikeRepository likeRepository,IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateLikeWithExistenceCheckCommand request, CancellationToken cancellationToken)
        {
            var like = await _likeRepository.GetAsync(request.Like.PostId, request.Like.AuthorId);

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
