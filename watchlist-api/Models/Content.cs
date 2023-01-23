using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace watchlist_api.Models
{
    public class Content
    {
        [Required]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        public Decimal Rating { get; set; }
        public virtual ICollection<WatchList> WatchLists { get; set; }
    }
}
