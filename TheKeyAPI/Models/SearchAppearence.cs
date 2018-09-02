using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheKey.Models
{
    /// <summary>
    /// Represents a found relevant result for a determinate search.
    /// </summary>
    public class SearchAppearence
    {        
        /// <summary>
        /// The order of appearence of the current result.
        /// </summary>
        public int AppearenceOrder { get; set; }
        /// <summary>
        /// The title of the link that redirects to the given url.
        /// </summary>
        public string LinkTitle { get; set; }

        public SearchAppearence(int order, string title)
        {
            AppearenceOrder = order;
            LinkTitle = title;
        }        
    }
}