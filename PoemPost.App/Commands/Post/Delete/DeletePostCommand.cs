using MediatR;

namespace PoemPost.App.Commands
{
    public class DeletePostCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
