using System.ComponentModel.DataAnnotations;


namespace watchlist_api.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<WatchList> WatchLists { get; set; }
    }
}
