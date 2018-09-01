using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TheKey.Models;

namespace TheKey.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        [HttpGet("[action]")]
        public List<SearchAppearence> GetUrlAppeareances()
        {
            ISearchHelper g = new GoogleSearchHelper();
            return g.searchUrlAppearences("infotrack.com.au", "online title search");
        }        
    }
}
