using MediatR;

namespace PoemPost.App.Commands
{
    public class DeletePostCommand : IRequest
    {
        public int Id { get; set; }
    }
}
