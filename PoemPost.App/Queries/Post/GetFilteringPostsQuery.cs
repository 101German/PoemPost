using MediatR;
using PoemPost.Data.DTO;
using PoemPost.Data.RequestFeauters;

namespace PoemPost.App.Queries
{
    public class GetFilteringPostsQuery : IRequest<PagedList<PostDTO>>
    {
        public bool TrackChanges { get; set; }
        public PostParameters PostParameters { get; set; }
    }
}
