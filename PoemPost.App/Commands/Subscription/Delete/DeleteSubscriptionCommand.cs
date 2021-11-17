using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.App.Commands.Delete
{
    public class DeleteSubscriptionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
