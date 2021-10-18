using MediatR;

namespace PoemPost.App.Commands
{
    public class DeleteAuthorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
