using MediatR;

namespace PoemPost.App.Commands.Delete
{
    public class DeleteCommentCommand : IRequest
    {
       public int Id { get; set; }
    }
}
