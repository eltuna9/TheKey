using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private int appearenceOrder { get; set; }
        /// <summary>
        /// The title of the link that redirects to the given url.
        /// </summary>
        private string linkTitle { get; set; }

        public SearchAppearence(int order, string title) {
            appearenceOrder = order;
            linkTitle = title;
        }
    }
}
