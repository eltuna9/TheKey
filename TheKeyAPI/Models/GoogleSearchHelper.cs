using System.Collections.Generic;
using System.Text;

namespace TheKey.Models
{
    public class GoogleSearchHelper : ISearchHelper
    {
        private const string BASE_SEARCH_URL = "https://www.google.com.au/search?q=";
        private int NumberOfResults;

        public GoogleSearchHelper()
        {
            NumberOfResults = 100;
        }

        /// <summary>
        /// Builds the URL to perform the search.
        /// </summary>
        /// <param name="keywords">The terms to be searched.</param>
        /// <returns>A url representing a valid url for a google search.</returns>
        private string BuildSearchUrl(string keywords)
        {
            StringBuilder builtUrl = new StringBuilder(BASE_SEARCH_URL);
            builtUrl.Append(keywords.Replace(" ", "+"));
            builtUrl.Append(string.Format("&num={0}", NumberOfResults));
            return builtUrl.ToString();
        }        

        /// <summary>
        /// Executes a Google search for the given keywords.
        /// </summary>
        /// <param name="url">The url to find in the Google search results</param>
        /// <param name="keyWords">The terms to be searched.</param>
        /// <returns>A list of SearchAppearence objects</returns>
        public List<SearchAppearence> SearchUrlAppearences(string url, string keyWords)
        {            
            string searchUrl = BuildSearchUrl(keyWords);
            HtmlHelper htmlHelper = new HtmlHelper();
            string htmlResponse = htmlHelper.GetHtmlFromUrl(searchUrl);            
            List<SearchAppearence> appearencesList = htmlHelper.GetUrlAppearencesInHtml(url, htmlResponse);
            return appearencesList;
        }      
    }
}