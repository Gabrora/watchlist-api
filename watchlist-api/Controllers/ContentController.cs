using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using watchlist_api.Data;
using watchlist_api.Models;
using Microsoft.EntityFrameworkCore;


namespace watchlist_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly watchlist_apiContext _context;

        public ContentController(watchlist_apiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetContentByName(string title)
        {

            var ContentList = await _context.Content.Where(x => x.Title.ToLower()
                              .Contains(title.ToLower()))
                              .Select(x => new { x.Title, x.Category, x.ReleaseDate, x.Rating }).ToListAsync();
            if (ContentList.Count == 0)           
                Ok("no content available with such name");
            

            return Ok(ContentList);
        }
    }
}
