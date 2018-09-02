﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace TheKey.Models
{
    public class GoogleSearchHelper : ISearchHelper
    {
        private const string BASE_SEARCH_URL = "https://www.google.com.au/search?q=";
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
        private string BuildSearchUrl(string keywords)
        {
            StringBuilder builtUrl = new StringBuilder(BASE_SEARCH_URL);
            builtUrl.Append(keywords.Replace(" ", "+"));
            builtUrl.Append("&num=").Append(numberOfResults);
            return builtUrl.ToString();
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

        /// <summary>
        /// Executes a Google search for the given keywords.
        /// </summary>
        /// <param name="url">The url to find in the Google search results</param>
        /// <param name="keyWords">The terms to be searched.</param>
        /// <returns>A list of SearchAppearence objects</returns>
        public List<SearchAppearence> SearchUrlAppearences(string url, string keyWords)
        {
            List<SearchAppearence> appearencesList = new List<SearchAppearence>();
            string searchUrl = BuildSearchUrl(keyWords);
            string htmlResponse = new RequestHelper().getHtmlFromUrl(searchUrl);
            MatchCollection searchResults = Regex.Matches(htmlResponse, @"<h3[^>]+?>(.*?)<\/h3>");

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
    }
}