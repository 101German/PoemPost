using MediatR;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Queries
{
    public class GetAuthorIdByUserIdQueryHandler : IRequestHandler<GetAuthorIdByUserIdQuery, int>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorIdByUserIdQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<int> Handle(GetAuthorIdByUserIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAuthorByUserId(request.UserId);
            if (author == null)
            {
                return 0;
            }
            return author.Id;
        }
    }
}
