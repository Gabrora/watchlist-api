namespace watchlist_api.Models
{
    public class AddWatchList
    {
        public int UserId { get; set; }
        public int ContentId { get; set; }
        public bool IsWatched { get; set; }
    }
}
