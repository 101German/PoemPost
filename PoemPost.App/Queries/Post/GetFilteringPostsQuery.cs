using MediatR;
using PoemPost.Data.RequestFeauters;

namespace PoemPost.App.Queries
{
    public class GetFilteringPostsQuery : IRequest<PagedList<Data.Models.Post>>
    {
        public bool TrackChanges { get; set; }
        public PostParameters PostParameters { get; set; }
    }
}
