using MediatR;
using PoemPost.Data.DataTransferObjects;

namespace PoemPost.Host.Commands
{
    public class UpdateAuthorCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public AuthorForUpdateDTO Author { get; set; }
    }
}
