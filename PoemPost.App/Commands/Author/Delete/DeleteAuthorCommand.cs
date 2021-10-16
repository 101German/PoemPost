using MediatR;

namespace PoemPost.App.Commands
{
    public class DeleteAuthorCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
