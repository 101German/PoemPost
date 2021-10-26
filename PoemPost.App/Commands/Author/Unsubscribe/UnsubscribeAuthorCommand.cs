using MediatR;
using Models;

namespace PoemPost.App.Command.Unsubscribe
{
    public class UnsubscribeAuthorCommand : IRequest
    {
        public UserForUnsubscription User { get; set; }
    }
}
