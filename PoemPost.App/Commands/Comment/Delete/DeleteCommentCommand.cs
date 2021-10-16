using MediatR;

namespace PoemPost.App.Commands.Delete
{
    public class DeleteCommentCommand : IRequest<bool>
    {
       public int Id { get; set; }
    }
}
