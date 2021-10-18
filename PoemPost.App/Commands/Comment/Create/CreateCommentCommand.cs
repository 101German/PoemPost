using MediatR;
using PoemPost.Data.DTO;

namespace PoemPost.App.Commands.Create
{
    public class CreateCommentCommand : IRequest<CommentDTO>
    {
        public CommentForCreationDTO Comment { get; set; }
     
    }
}
