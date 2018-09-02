using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace TheKey.Models
{
    /// <summary>
    /// Object responsible for the manipulation and obtainment of the html.
    /// </summary>
    public class HtmlHelper
    {
        private const string REGEX_SEARCH_RESULT = @"<h3[^>]+?>(.*?)<\/h3>";

        /// <summary>
        /// Executes an http request and returns the html as a string.
        /// </summary>
        /// <param name="url">The url to execute the http request.</param>
        /// <returns>The html response from the server, in a string format.</returns>
        public string GetHtmlFromUrl(string url)
        {            
            try
            {
                string html = string.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occured while trying to perform the search request.", ex);
            }
            
        }

        /// <summary>
        /// Find the appearences of the url in a valid result tag.
        /// </summary>
        /// <param name="url">The url to be found in the search result html.</param>
        /// <param name="htmlToLookUp">A string containing the html response.</param>
        /// <returns>A collection of SearchAppearence objects.</returns>
        public List<SearchAppearence> GetUrlAppearencesInHtml(string url, string htmlToLookUp)
        {
            MatchCollection searchResults = Regex.Matches(htmlToLookUp, REGEX_SEARCH_RESULT);
            List<SearchAppearence> appearencesList = new List<SearchAppearence>();
            //To improve the search results, the protocol is deleted from the url.
            string urlWithoutProtocol = Regex.Replace(url, @"/^.*:\/\//i", string.Empty);
            for (int i = 0; i < searchResults.Count; i++)
            {
                string appearenceString = searchResults[i].Value;
                if (appearenceString.Contains(url))
                {
                    int appearenceOrder = i + 1;
                    string linkTitle = GetAppearanceLinkTitle(appearenceString);
                    SearchAppearence appearence = new SearchAppearence(appearenceOrder, linkTitle);
                    appearencesList.Add(appearence);
                }
            }
            return appearencesList;
        }

        /// <summary>
        /// Given a string representing an html node for an appearence, returns the relevant title of it.
        /// </summary>
        /// <param name="result">A string representing an appearence html code</param>
        /// <returns>The title of the link in the search appearence.</returns>
        private string GetAppearanceLinkTitle(string result)
        {
            return Regex.Replace(result, @"<.*?>|</.*?>", string.Empty);
        }
    }
}