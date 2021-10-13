using MediatR;
using PoemPost.Data.DataTransferObjects;

namespace PoemPost.Host.Commands.Create
{
    public class CreateCommentCommand : IRequest<CommentDTO>
    {
        public CommentForCreationDTO Comment { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }
    }
}
