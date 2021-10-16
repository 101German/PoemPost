using MediatR;
using PoemPost.Data.DTO;
using System.Collections.Generic;

namespace PoemPost.Host.Queries
{
    public class GetAuthorsQuery : IRequest<List<AuthorDTO>>
    {
        public bool TrackChanges { get; set; }
    }
}
