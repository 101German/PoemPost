using MediatR;

namespace PoemPost.Host.Commands
{
    public class DeleteAuthorCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
