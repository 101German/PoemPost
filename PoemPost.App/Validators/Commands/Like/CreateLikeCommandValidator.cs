using FluentValidation;
using PoemPost.App.Commands.Like.Create;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Validators
{
    public class CreateLikeCommandValidator : AbstractValidator<CreateLikeWithValidateOnExistCommand>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IPostRepository _postRepository;
        public CreateLikeCommandValidator(IAuthorRepository authorRepository,IPostRepository postRepository)
        {
            _authorRepository = authorRepository;
            _postRepository = postRepository;

            RuleFor(l => l.Like).NotEmpty().WithMessage("Parameter Like is null");
            RuleFor(l => l.Like.PostId).MustAsync(ValidatePostOnExistAsync).WithMessage("This post does not exist");
            RuleFor(l => l.Like.AuthorId).MustAsync(ValidateAuthorOnExistAsync).WithMessage("This author does not exist");
        }

        private async Task<bool> ValidateAuthorOnExistAsync(int id, CancellationToken ct)
                                                => await _authorRepository.GetByIdAsync(id, trackChanges: true) != null;
        private async Task<bool> ValidatePostOnExistAsync(int id, CancellationToken ct) 
                                                => await _postRepository.GetByIdAsync(id, trackChanges: true) != null;

    }
}
