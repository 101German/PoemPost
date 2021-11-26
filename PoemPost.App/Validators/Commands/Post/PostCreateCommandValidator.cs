using FluentValidation;
using PoemPost.App.Commands;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Validators.Post
{
    public class PostCreateCommandValidator : AbstractValidator<CreatePostCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public PostCreateCommandValidator(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
           
            RuleFor(p => p.Post)
                .NotNull()
                .WithMessage("Parameter Post is null");
        }

        private async Task<bool> AuthorExistAsync(int id, CancellationToken ct) =>
            await _authorRepository.GetByIdAsync(id, trackChanges: false) != null;
    }
}
