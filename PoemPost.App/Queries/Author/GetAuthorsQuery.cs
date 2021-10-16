using MediatR;
using PoemPost.Data.DTO;
using System.Collections.Generic;

namespace PoemPost.App.Queries
{
    public class GetAuthorsQuery : IRequest<List<AuthorDTO>>
    {
        public bool TrackChanges { get; set; }
    }
}
