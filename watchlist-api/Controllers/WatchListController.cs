using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using watchlist_api.Data;
using watchlist_api.Models;

namespace watchlist_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
        private readonly watchlist_apiContext _context;

        public WatchListController(watchlist_apiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetWatchlist(int UserId)
        {

            if (!_context.User.Any(x => x.Id.Equals(UserId)))
                return NotFound("such user does not exist");

            var watchList = _context.WatchList.Where(x => x.UserId.Equals(UserId)).Select(x => new { x.ContentId, x.hasWatched });
            var response = await _context.Content
                                 .Join(watchList, c => c.Id, w => w.ContentId, (c, w) => new { Content = c, WatchList = w })
                                 .Select(x => new { x.Content.Title, x.Content.Category, x.Content.Rating, x.Content.ReleaseDate, x.WatchList.hasWatched })
                                 .ToListAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> PostWatchlist(AddWatchList wishlist)
        {
            WatchList newContent = new WatchList();

            var x = _context.User.Any(x => x.Id.Equals(wishlist.UserId));

            if (_context.WatchList.Where(x => x.UserId.Equals(wishlist.UserId)).Select(x => x.ContentId).Contains(wishlist.ContentId))
                return Ok("item already in the watchlist");

            else if (!_context.User.Any(x => x.Id.Equals(wishlist.UserId)))
                return NotFound("such user does not exist");

            else if (!_context.Content.Any(x => x.Id.Equals(wishlist.ContentId)))
                return NotFound("such content does not exist");

            else if (!_context.WatchList.Where(x => x.UserId.Equals(wishlist.UserId)).Select(x => x.ContentId).Contains(wishlist.ContentId))
            {
                newContent.UserId = wishlist.UserId;
                newContent.ContentId = wishlist.ContentId;
                _context.WatchList.Add(newContent);
                await _context.SaveChangesAsync();
            }
            return Ok("watchlist updated successfully");
        }



    }
}
