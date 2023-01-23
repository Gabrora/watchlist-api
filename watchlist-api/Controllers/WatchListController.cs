using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using watchlist_api.Data;
using watchlist_api.Interfaces;
using watchlist_api.Models;

namespace watchlist_api.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
        private readonly watchlist_apiContext _context;
        private readonly IWatchListValidator _watchListValidator;

        public WatchListController(watchlist_apiContext context, IWatchListValidator watchListValidator)
        {
            _context = context;
            _watchListValidator = watchListValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetWatchlist(int UserId)
        {

            if (!_context.User.Any(x => x.Id.Equals(UserId)))
                return NotFound("such user does not exist");

            var watchList = _context.WatchList
                            .Where(x => x.UserId
                            .Equals(UserId))
                            .Select(x => new { x.ContentId, x.hasWatched });

            var response = await _context.Content
                                 .Join(watchList, c => c.Id, w => w.ContentId, (c, w) => new { Content = c, WatchList = w })
                                 .Select(x => new { x.Content.Title, x.Content.Category, x.Content.Rating, x.Content.ReleaseDate, x.WatchList.hasWatched })
                                 .ToListAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostWatchlist(WatchListModel model)
        {
            var results = _watchListValidator.Validate(model);

            if (results.IsValid)
            {
                var watchlLists = _context.WatchList
                     .Where(x => x.UserId
                     .Equals(model.UserId))
                     .Select(x => x.ContentId)
                     .Contains(model.ContentId);

                if (watchlLists)
                    return Ok("item already in the watchlist");

                else if (!watchlLists)
                {
                    _context.WatchList.Add(new WatchList { UserId = model.UserId, ContentId = model.ContentId });
                    await _context.SaveChangesAsync();
                }
                return Ok("watchlist updated successfully");
            }
            return NotFound(results.Errors);

   
        }

        [HttpPatch]
        public async Task<IActionResult> PatchWatchList(WatchListModel model)
        {
            var results = _watchListValidator.Validate(model);
            if (results.IsValid)
            {
                var response = _context.WatchList
                          .FirstOrDefault(x => x.UserId
                          .Equals(model.UserId) && x.ContentId
                          .Equals(model.ContentId));

                if (response == null)
                    return NotFound("user and/or content not found in the watchlist");

                if (response.hasWatched)
                    return Ok("Content is already watched");

                response.hasWatched = true;
                await _context.SaveChangesAsync();
                return Ok("watchlist updated successfully");
            }
            return NotFound(results.Errors);

        }

    }
}
