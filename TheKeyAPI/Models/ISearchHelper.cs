using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheKey.Models
{
    interface ISearchHelper
    {
        Task<IEnumerable<SearchAppearence>> SearchUrlAppearences(string url, string keyWords);
    }
}

