using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TldProvider.Core
{
    public class TldListProvider : ITldListProvider
    {
        public List<Tld> GetSupportedTldList(string url)
        {
            Uri supportedTldPage = new Uri(url);
            string pageHtml = string.Empty;
            using (var webclient = new WebClient())
            {
                pageHtml = webclient.DownloadString(supportedTldPage);
            }

            string pattern = "<a class=\"xref\" href=\"registrar-tld-list.html#.+?\">[.](.+?)</a>";
            var matches = Regex.Matches(pageHtml, pattern);

            var result = new List<Tld>();
            foreach (Match m in matches)
            {
                result.Add(new Tld() { Name = m.Groups[1].Value });
            }

            return result;
        }
    }

}
