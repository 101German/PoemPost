using MediatR;
using PoemPost.Data.DataTransferObjects.Like;

namespace PoemPost.Host.Commands.Like.Create
{
    public class CreateLikeCommand : IRequest<bool>
    {
        public LikeForCreationDTO Like { get; set; }
    }
}
