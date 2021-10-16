﻿using MediatR;
using PoemPost.Data.DTO;

namespace PoemPost.Host.Commands
{
    public class CreateAuthorCommand : IRequest<AuthorDTO>
    {
        public AuthorForCreationDTO Author { get; set; }
    }
}
