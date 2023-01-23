using watchlist_api.Models;
namespace watchlist_api.Data
{
    public class DbSeeder
    {
        public static void Seed(watchlist_apiContext context)
        {
            context.Database.EnsureCreated();

            if (!context.User.Any() && !context.Content.Any())
            {
                context.User.Add(new User { Name = "Mike" });
                context.User.Add(new User { Name = "Tommy" });
                context.User.Add(new User { Name = "Johny" });
                context.User.Add(new User { Name = "Nick" });
                context.User.Add(new User { Name = "David" });
                context.Content.Add(new Content { Title = "Nightcrawler", Category = "Movie", ReleaseDate = new DateTime(2014, 10, 31), Rating = 7.8M });
                context.Content.Add(new Content { Title = "Taxi Driver", Category = "Movie", ReleaseDate = new DateTime(1976, 02, 08), Rating = 8.2M });
                context.Content.Add(new Content { Title = "Arcane", Category = "TV series", ReleaseDate = new DateTime(2021, 11, 06), Rating = 9.0M });
                context.Content.Add(new Content { Title = "American Psycho", Category = "Movie", ReleaseDate = new DateTime(2000, 4, 14), Rating = 7.6M });
                context.SaveChanges();
            }
        }
    }
}
