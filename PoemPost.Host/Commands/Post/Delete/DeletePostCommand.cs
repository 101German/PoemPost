using MediatR;

namespace PoemPost.Host.Commands
{
    public class DeletePostCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
