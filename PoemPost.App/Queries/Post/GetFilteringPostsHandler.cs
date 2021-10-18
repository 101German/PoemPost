using AutoMapper;
using MediatR;
using PoemPost.Data.DTO;
using PoemPost.Data.Interfaces;
using PoemPost.Data.RequestFeauters;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PoemPost.Data.Models;

namespace PoemPost.App.Queries
{
    public class GetFilteringPostsHandler : IRequestHandler<GetFilteringPostsQuery,PagedList<Data.Models.Post>>
    {
        private readonly IPostRepository _postRepository;
   
        public GetFilteringPostsHandler(IPostRepository postRepository,IMapper mapper)
        {
            _postRepository = postRepository;
        }

        public async Task<PagedList<Data.Models.Post>> Handle(GetFilteringPostsQuery request, CancellationToken cancellationToken)
        {
            var postsEntities = await _postRepository.GetWithFiltersAsync(request.PostParameters, request.TrackChanges);

            return postsEntities;
        }
    }
}
