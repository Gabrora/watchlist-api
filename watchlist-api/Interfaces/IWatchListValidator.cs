using FluentValidation.Results;
using watchlist_api.Models;

namespace watchlist_api.Interfaces
{
    public interface IWatchListValidator
    {
        ValidationResult Validate(WatchListModel model);
    }
}
