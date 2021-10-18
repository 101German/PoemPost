using FluentValidation;
using PoemPost.App.Commands.Update;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Validators.Post
{
    public class PostUpdateCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        private readonly IPostRepository _postRepository;

        public PostUpdateCommandValidator(IPostRepository postRepository)
        {
            _postRepository = postRepository;

            RuleFor(p => p.Id)
                .MustAsync(ValidatePostOnExist)
                .WithMessage("This post does not exist");
        }

        private async Task<bool> ValidatePostOnExist(int id, CancellationToken ct)
            => await _postRepository.GetByIdAsync(id, trackChanges: true) != null;
    }
}
