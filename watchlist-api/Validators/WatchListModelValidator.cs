using FluentValidation;
using watchlist_api.Data;
using watchlist_api.Interfaces;
using watchlist_api.Models;

namespace watchlist_api.Validators
{
    public class WatchListModelValidator : AbstractValidator<WatchListModel>, IWatchListValidator 
    {
        private readonly watchlist_apiContext _context;
        public WatchListModelValidator(watchlist_apiContext context)
        {
            _context = context;
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ContentId).NotEmpty();
            RuleFor(x => x.UserId).Must(UserExists).WithMessage("User not found");
            RuleFor(x => x.ContentId).Must(ContentExists).WithMessage("Content not found");
        }
        private bool UserExists(int userId)
        {
            return _context.User.Any(x => x.Id == userId);
        }
        private bool ContentExists(int contentId)
        {
            return _context.Content.Any(x => x.Id == contentId);
        }

    }
}
