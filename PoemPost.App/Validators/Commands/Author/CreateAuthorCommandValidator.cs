using FluentValidation;
using PoemPost.App.Commands;

namespace PoemPost.App.Validators
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(a => a.Author)
                .NotNull()
                .WithMessage("Parameter Author is null");
        }
    }
}
