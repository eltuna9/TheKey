using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheKey.Models
{
    interface ISearchHelper
    {
        List<SearchAppearence> SearchUrlAppearences(string url, string keyWords);
    }
}

