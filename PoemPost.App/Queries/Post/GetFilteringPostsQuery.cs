using MediatR;
using PoemPost.Data.DTO;
using PoemPost.Data.RequestFeauters;
using System.Collections.Generic;

namespace PoemPost.App.Queries.Post
{
    public class GetFilteringPostsQuery : IRequest<ICollection<PostDTO>>
    {
        public bool TrackChanges { get; set; }
        public PostParameters PostParameters { get; set; }
    }
}
