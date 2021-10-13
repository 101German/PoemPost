using MediatR;
using PoemPost.Data.DataTransferObjects;

namespace PoemPost.Host.Commands
{
    public class CreateAuthorCommand : IRequest<AuthorDTO>
    {
        public AuthorForCreationDTO Author { get; set; }
    }
}
