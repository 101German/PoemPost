using MediatR;

namespace PoemPost.Host.Commands.Delete
{
    public class DeleteCommentCommand : IRequest<bool>
    {
       public int Id { get; set; }
    }
}
