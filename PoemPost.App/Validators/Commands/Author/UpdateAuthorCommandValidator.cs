using FluentValidation;
using PoemPost.App.Commands;
using PoemPost.Data.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoemPost.App.Validators
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;
        public UpdateAuthorCommandValidator(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

            RuleFor(a => a.Id)
                .MustAsync(ValidateAuthorOnExist)
                .WithMessage("This author does not exist");
        }

        private async Task<bool> ValidateAuthorOnExist(int id, CancellationToken ct) => await _authorRepository
                                                                                             .GetByIdAsync(id, trackChanges: true) != null;

    }
}
