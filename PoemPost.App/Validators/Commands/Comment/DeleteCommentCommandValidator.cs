using FluentValidation;
using PoemPost.App.Commands.Delete;
using PoemPost.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Validators.Comment
{
    public class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandValidator(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;

            RuleFor(c => c.Id).MustAsync(ValidateCommentOnExist).WithMessage("This comment does not exist");
        }

        private async Task<bool> ValidateCommentOnExist(int id, CancellationToken ct) => await _commentRepository.GetByIdAsync(id, trackChanges: true) != null;

    }
}
