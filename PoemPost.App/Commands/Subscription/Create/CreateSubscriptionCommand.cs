using MediatR;
using PoemPost.Data.DTO.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.App.Commands
{
    public class CreateSubscriptionCommand : IRequest<SubscriptionDTO>
    {
        public SubscriptionForCreateDTO Subscription { get; set; }
    }
}
