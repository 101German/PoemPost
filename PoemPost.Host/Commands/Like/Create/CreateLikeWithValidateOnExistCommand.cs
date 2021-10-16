using MediatR;
using PoemPost.Data.DTO.Like;

namespace PoemPost.Host.Commands.Like.Create
{
    public class CreateLikeWithValidateOnExistCommand : IRequest<bool>
    {
        public LikeForCreationDTO Like { get; set; }
    }
}
