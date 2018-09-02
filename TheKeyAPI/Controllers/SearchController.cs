using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Web.Http;
using TheKey.Models;
using System.Net;
using System.Web;
using TheKey.Utils;
using System.Web.Http.Cors;

namespace TheKey.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SearchController : ApiController
    {
        [HttpGet]
        [Route("api/search/")]        
        public HttpResponseMessage GetUrlAppeareances([FromUri]string url, [FromUri]string keyWords)
        {
            try
            {                
                string decodedUrl = HttpUtility.UrlDecode(url);
                string decodedKeywords = HttpUtility.UrlDecode(keyWords);
                Logger.log.Info(String.Format("[{0}] Starting the searching for {1} | in the results for [{2}]", Request.GetCorrelationId(), url, keyWords));
                ISearchHelper searchHelper = new GoogleSearchHelper();
                IEnumerable<SearchAppearence> appearences = searchHelper.SearchUrlAppearences(decodedUrl, decodedKeywords);
                Logger.log.Info(String.Format("[{0}] Returning results for {1} | in the results for [{2}]", Request.GetCorrelationId(), url, keyWords));
                return Request.CreateResponse(HttpStatusCode.OK, appearences);
            }
            catch (Exception ex)
            {
                Logger.log.Error(String.Format("[{0}] Exception trying to get appeareances for {1} | in the results for [{2}] ", Request.GetCorrelationId(), url, keyWords), ex.InnerException);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}