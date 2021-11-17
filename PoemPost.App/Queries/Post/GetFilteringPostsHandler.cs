using AutoMapper;
using MediatR;
using PoemPost.Data.DTO;
using PoemPost.Data.Interfaces;
using PoemPost.Data.RequestFeauters;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Queries
{
    public class GetFilteringPostsHandler : IRequestHandler<GetFilteringPostsQuery, PagedList<PostDTO>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetFilteringPostsHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<PostDTO>> Handle(GetFilteringPostsQuery request, CancellationToken cancellationToken)
        {
            var postsEntities = await _postRepository.GetWithFiltersAsync(request.PostParameters, request.TrackChanges);

            return _mapper.Map<PagedList<PostDTO>>(postsEntities);
        }
    }
}
