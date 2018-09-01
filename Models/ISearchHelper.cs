using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheKey.Models
{
    interface ISearchHelper
    {
        List<SearchAppearence> searchUrlAppearences(string url, string keyWords);
    }
}
