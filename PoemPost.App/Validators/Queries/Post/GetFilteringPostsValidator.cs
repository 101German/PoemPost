using FluentValidation;
using PoemPost.App.Queries.Post;

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
