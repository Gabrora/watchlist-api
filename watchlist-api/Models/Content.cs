using System.ComponentModel.DataAnnotations;

namespace watchlist_api.Models
{
    public class Content
    {
        [Required]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Decimal Rating { get; set; }
        public virtual ICollection<WatchList> WatchLists { get; set; }
    }
}
