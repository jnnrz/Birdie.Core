using FluentValidation;

namespace Birdie.Core.Data.Entities
{
    public class SavedSearch
    {
        public long Id { get; set; }
        public string Search { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }

    public class SavedSearchValidator : AbstractValidator<SavedSearch>
    {
        public SavedSearchValidator()
        {
            RuleFor(ss => ss.Search).MaximumLength(40).NotEmpty();
        }
    }
}