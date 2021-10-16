using FluentValidation;
using PoemPost.App.Commands.Like.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
