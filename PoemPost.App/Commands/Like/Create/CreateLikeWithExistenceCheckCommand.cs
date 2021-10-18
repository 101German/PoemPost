using MediatR;
using PoemPost.Data.DTO.Like;

namespace PoemPost.App.Commands.Like.Create
{
    public class CreateLikeWithExistenceCheckCommand : IRequest<bool>
    {
        public LikeForCreationDTO Like { get; set; }
    }
}
