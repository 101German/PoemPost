using FluentValidation;
using PoemPost.App.Commands;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Validators.Post
{
    public class PostDeleteCommandValidator : AbstractValidator<DeletePostCommand>
    {
        private readonly IPostRepository _postRepository;

        public PostDeleteCommandValidator(IPostRepository postRepository)
        {
            _postRepository = postRepository;

            RuleFor(p => p.Id).MustAsync(ValidatePostOnExist).WithMessage("This post does not exist");
        }

        private async Task<bool> ValidatePostOnExist(int id,CancellationToken ct) =>
            await _postRepository.GetByIdAsync(id, trackChanges: true) != null;
    }
}
