using MediatR;
using PoemPost.Data.DataTransferObjects;

namespace PoemPost.Host.Commands.Update
{
    public class UpdatePostCommand : IRequest<bool>
    {
        public PostForUpdateDTO Post { get; set; }
        public int Id { get; set; }
    }
}
