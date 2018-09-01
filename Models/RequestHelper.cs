using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TheKey.Models
{
    /// <summary>
    /// Object responsabile of execute the http request.
    /// </summary>
    public class RequestHelper
    {
        /// <summary>
        /// Executes an http request and returns the html as a string.
        /// </summary>
        /// <param name="url">The url to execute the http request.</param>
        /// <returns>The html response from the server, in a string format.</returns>
        public string getHtmlFromUrl(string url)
        {
            string html = string.Empty;
            url = @"https://www.google.com.au/search?q=online+title+search&num=100&oq=online+title+search&cr=au";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
