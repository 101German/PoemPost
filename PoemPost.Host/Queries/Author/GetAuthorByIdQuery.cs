﻿using MediatR;
using PoemPost.Data.DataTransferObjects;

namespace PoemPost.Host.Queries
{
    public class GetAuthorByIdQuery : IRequest<AuthorDTO>
    {
        public int Id { get; set; }
        public bool TrackChanges { get; set; }
    }
}
