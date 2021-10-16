using MediatR;
using PoemPost.Data.DTO;

namespace PoemPost.Host.Queries.Post
{
    public class GetPostByIdQuery : IRequest<PostDTO>
    {
        public int Id { get; set; }
        public bool TrackChanges { get; set; }
    }
}
