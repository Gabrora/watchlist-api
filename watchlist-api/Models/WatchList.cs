using System.ComponentModel.DataAnnotations;

namespace watchlist_api.Models
{
    public class WatchList
    {
        [Required]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ContentId { get; set; }
        public Content Content { get; set; }
        public bool hasWatched { get; set; } = false;
    }
}
