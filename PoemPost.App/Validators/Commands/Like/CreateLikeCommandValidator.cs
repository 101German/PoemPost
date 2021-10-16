using FluentValidation;
using PoemPost.App.Commands.Like.Create;

namespace PoemPost.App.Validators
{
    public class CreateLikeCommandValidator : AbstractValidator<CreateLikeWithValidateOnExistCommand>
    {
        public CreateLikeCommandValidator()
        {
            RuleFor(l => l.Like).NotEmpty().WithMessage("Parameter Like is null");
        }
    }
}
