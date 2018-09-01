using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TheKey.Models
{
    public class GoogleSearchHelper : ISearchHelper
    {
        private const string BLANK_SPACE = " ";
        private const string PLUS_SIGN = "+";
        private const string BASE_SEARCH_URL = "https://www.google.com.au/search?q=";
        private const string NUMBER_QUERY_PARAM = "&num=";
        private int numberOfResults;
        
        public GoogleSearchHelper()
        {
            numberOfResults = 100;
        }

        /// <summary>
        /// Builds the URL to perform the search.
        /// </summary>
        /// <param name="keywords">The terms to be searched.</param>
        /// <returns>A url representing a valid url for a google search.</returns>
        private string buildSearchUrl(string keywords)
        {
            StringBuilder builtUrl = new StringBuilder(BASE_SEARCH_URL);
            builtUrl.Append(keywords.Replace(BLANK_SPACE, PLUS_SIGN));
            builtUrl.Append(NUMBER_QUERY_PARAM).Append(numberOfResults);
            return builtUrl.ToString();
        }

        /// <summary>
        /// Given a string representing an html node for an appearence, returns the relevant title of it.
        /// </summary>
        /// <param name="result">A string representing an appearence html code</param>
        /// <returns>The title of the link in the search appearence.</returns>
        private string getAppearanceLinkTitle(string result) {
            string title = string.Empty;
            return title;
        }

        /// <summary>
        /// Executes a Google search for the given keywords.
        /// </summary>
        /// <param name="url">The url to find in the Google search results</param>
        /// <param name="keyWords">The terms to be searched.</param>
        /// <returns>A list of SearchAppearence objects</returns>
        public List<SearchAppearence> searchUrlAppearences(string url, string keyWords)
        {
            List<SearchAppearence> appearencesList = new List<SearchAppearence>();
            string searchUrl = buildSearchUrl(keyWords);
            string htmlResponse = new RequestHelper().getHtmlFromUrl(searchUrl);
            //<\s*h3[^>]*>.*(www.infotrack.com.au+?).*<\s*\/h3>
            MatchCollection searchResults = Regex.Matches(htmlResponse, @"<\s*h3[^>]*>.*<\s*\/h3>");

            for (int i = 0; i < searchResults.Count; i++)
            {
                string appearenceString = searchResults[i].Value;
                if (appearenceString.Contains(url))
                {
                    int appearenceOrder = i + 1;
                    string linkTitle = getAppearanceLinkTitle(appearenceString);
                    SearchAppearence appearence = new SearchAppearence(appearenceOrder, linkTitle);
                    appearencesList.Add(appearence);
                }
            }

            return appearencesList;
        }
    }
}
