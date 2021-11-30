using MediatR;

namespace PoemPost.App.Commands.Delete
{
    public class DeleteSubscriptionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
