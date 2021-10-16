using AutoMapper;
using MediatR;
using PoemPost.Data.DTO;
using PoemPost.Data.Interfaces;
using PoemPost.Data.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.Host.Commands.Create
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CommentDTO>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<CommentDTO> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var commentEntity = _mapper.Map<Comment>(request.Comment);

            commentEntity.CreationDate = DateTime.Now;
            

            _commentRepository.Insert(commentEntity);
            await _commentRepository.SaveAsync();

            var commentToReturn = _mapper.Map<CommentDTO>(commentEntity);

            return commentToReturn;
        }
    }
}
