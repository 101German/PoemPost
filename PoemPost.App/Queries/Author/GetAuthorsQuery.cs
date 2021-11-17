using MediatR;
using PoemPost.Data.DTO;
using PoemPost.Data.Models;
using PoemPost.Data.RequestFeauters;
using System.Collections.Generic;

namespace PoemPost.App.Queries
{
    public class GetAuthorsQuery : IRequest<PagedList<AuthorDTO>>
    {
        public AuthorParameters AuthorParameters{ get; set; }
        public bool TrackChanges { get; set; }
    }
}
