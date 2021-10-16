using MediatR;
using PoemPost.Data.DTO;

namespace PoemPost.App.Commands
{
    public class CreatePostCommand : IRequest<PostDTO>
    {
        public PostForCreationDTO Post { get; set; }
        
    }
}
