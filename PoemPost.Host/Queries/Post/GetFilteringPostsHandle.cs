using AutoMapper;
using MediatR;
using PoemPost.Data.DataTransferObjects;
using PoemPost.Data.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.Host.Queries.Post
{
    public class GetFilteringPostsHandle : IRequestHandler<GetFilteringPosts, ICollection<PostDTO>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetFilteringPostsHandle(IPostRepository postRepository,IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<PostDTO>> Handle(GetFilteringPosts request, CancellationToken cancellationToken)
        {
            var postsEntities =await _postRepository.GetWithFiltersAsync(request.PostParameters, request.TrackChanges);
            return _mapper.Map<ICollection<PostDTO>>(postsEntities);
        }
    }
}
