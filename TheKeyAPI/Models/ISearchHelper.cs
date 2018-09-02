using System.Collections.Generic;

namespace TheKey.Models
{
    interface ISearchHelper
    {
        List<SearchAppearence> SearchUrlAppearences(string url, string keyWords);
    }
}

