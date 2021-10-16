using MediatR;
using PoemPost.Data.DTO.Like;

namespace PoemPost.App.Commands.Like.Create
{
    public class CreateLikeWithValidateOnExistCommand : IRequest<bool>
    {
        public LikeForCreationDTO Like { get; set; }
    }
}
