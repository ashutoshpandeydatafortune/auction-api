using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Models;
using SearchService.Models.DTO;

namespace SearchService.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController: ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Item>>> SearchItems([FromQuery]SearchDTO searchDTO)
        {
            var query = DB.PagedSearch<Item, Item>();

            if(!string.IsNullOrEmpty(searchDTO.SearchTerm))
            {
                query.Match(Search.Full, searchDTO.SearchTerm).SortByTextScore();
            }

            query = searchDTO.OrderBy switch
            {
                "make" => query.Sort(x => x.Ascending(a => a.Make)),
                "new" => query.Sort(x => x.Ascending(a => a.Make)),
                _ => query.Sort(x => x.Ascending(a => a.Make)),
            };

            query = searchDTO.FilterBy switch
            {
                "finished" => query.Match(x => x.AuctionEnd < DateTime.UtcNow),
                "endingSoon" => query.Match(x => x.AuctionEnd < DateTime.UtcNow.AddHours(6) && x.AuctionEnd > DateTime.UtcNow),
                _ => query.Match(x => x.AuctionEnd > DateTime.UtcNow),
            };

            query.PageSize(searchDTO.PageSize);
            query.PageNumber(searchDTO.PageNumber);

            var result = await query.ExecuteAsync();

            return Ok(new
            {
                results = result.Results,
                pageCount = result.PageCount,
                totalCount = result.TotalCount
            });
        }
    }
}
