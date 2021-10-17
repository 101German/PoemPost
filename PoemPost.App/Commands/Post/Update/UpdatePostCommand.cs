using MediatR;
using PoemPost.Data.DTO;

namespace PoemPost.App.Commands.Update
{
    public class UpdatePostCommand : IRequest
    {
        public PostForUpdateDTO Post { get; set; }
        public int Id { get; set; }
    }
}
