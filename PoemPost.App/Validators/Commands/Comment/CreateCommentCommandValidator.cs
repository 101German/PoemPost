using FluentValidation;
using PoemPost.App.Commands.Create;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Validators.Comment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        private readonly IPostRepository _postRepository;
        private readonly IAuthorRepository _authorRepository;

        public CreateCommentCommandValidator(IPostRepository postRepository,IAuthorRepository authorRepository)
        {
            _postRepository = postRepository;
            _authorRepository = authorRepository;

            RuleFor(c => c.Comment).NotNull().WithMessage("Parameter Comment is null");
            RuleFor(c => c.Comment.AuthorId).MustAsync(ValidateAuthorOnExistAsync).WithMessage("This author does not exist");
            RuleFor(c => c.Comment.PostId).MustAsync(ValidatePostOnExist).WithMessage("This post does not exist");

        }

        private async Task<bool> ValidateAuthorOnExistAsync(int id, CancellationToken ct) => await _authorRepository.GetByIdAsync(id, trackChanges: false) != null;
        private async Task<bool> ValidatePostOnExist(int id, CancellationToken ct) => await _postRepository.GetByIdAsync(id, trackChanges: true) != null;


    }
}
