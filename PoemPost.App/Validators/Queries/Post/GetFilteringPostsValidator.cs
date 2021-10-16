using FluentValidation;
using PoemPost.App.Queries.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoemPost.App.Validators.Queries.Post
{
    public class GetFilteringPostsValidator : AbstractValidator<GetFilteringPostsQuery>
    {
        public GetFilteringPostsValidator()
        {
            RuleFor(p => p.PostParameters).NotNull().WithMessage("Post parameters is null");
        }
        
    }
}
