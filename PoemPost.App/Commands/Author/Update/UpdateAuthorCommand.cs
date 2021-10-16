using MediatR;
using PoemPost.Data.DTO;

namespace PoemPost.App.Commands
{
    public class UpdateAuthorCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public AuthorForUpdateDTO Author { get; set; }
    }
}
