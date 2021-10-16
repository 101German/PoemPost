using MediatR;
using PoemPost.Data.DTO;

namespace PoemPost.App.Commands.Create
{
    public class CreateCommentCommand : IRequest<CommentDTO>
    {
        public CommentForCreationDTO Comment { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }
    }
}
