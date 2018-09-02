using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Web.Http;
using TheKey.Models;
using System.Net;
using System.Web;

namespace TheKey.Controllers
{

    public class SearchController : ApiController
    {
        [HttpGet]
        [Route("api/search/")]        
        public HttpResponseMessage GetUrlAppeareances([FromUri]string url, [FromUri]string keyWords)
        {
            try
            {
                ISearchHelper searchHelper = new GoogleSearchHelper();
                IEnumerable<SearchAppearence> appearences = searchHelper.SearchUrlAppearences(HttpUtility.UrlDecode(url), HttpUtility.UrlDecode(keyWords));
                return Request.CreateResponse(HttpStatusCode.OK, appearences);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}