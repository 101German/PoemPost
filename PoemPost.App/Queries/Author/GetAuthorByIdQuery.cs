using MediatR;
using PoemPost.Data.DTO;

namespace PoemPost.App.Queries
{
    public class GetAuthorByIdQuery : IRequest<AuthorDTO>
    {
        public int Id { get; set; }
        public bool TrackChanges { get; set; }
    }
}
