using MediatR;
using PoemPost.Data.DTO;

namespace PoemPost.Host.Commands
{
    public class CreatePostCommand : IRequest<PostDTO>
    {
        public PostForCreationDTO Post { get; set; }
        public int AuthorId { get; set; }
    }
}
