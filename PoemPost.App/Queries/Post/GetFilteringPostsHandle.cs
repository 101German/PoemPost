using AutoMapper;
using MediatR;
using PoemPost.Data.DTO;
using PoemPost.Data.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Queries.Post
{
    public class GetFilteringPostsHandle : IRequestHandler<GetFilteringPostsQuery, ICollection<PostDTO>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetFilteringPostsHandle(IPostRepository postRepository,IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<PostDTO>> Handle(GetFilteringPostsQuery request, CancellationToken cancellationToken)
        {
            var postsEntities =await _postRepository.GetWithFiltersAsync(request.PostParameters, request.TrackChanges);
            return _mapper.Map<ICollection<PostDTO>>(postsEntities);
        }
    }
}
