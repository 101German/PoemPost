using MediatR;
using Models;
using PoemPost.Data.DTO;
using PoemPost.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.App.Commands.Subscribe
{
    public class SubscribeOnAuthorCommand : IRequest
    {
        public UserForSubscription User { get; set; }
    }
}
