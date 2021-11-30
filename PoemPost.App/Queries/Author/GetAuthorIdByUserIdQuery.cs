using MediatR;
using System;

namespace PoemPost.App.Queries
{
    public class GetAuthorIdByUserIdQuery : IRequest<int>
    {
        public Guid UserId { get; set; }
    }
}
