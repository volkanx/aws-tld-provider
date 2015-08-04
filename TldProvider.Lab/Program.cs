using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TldProvider.Core;

namespace TldProvider.Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html";
            var tldListProvider = new TldListProvider();
            var tldList = tldListProvider.GetSupportedTldList(url);
            tldList.ForEach(tld => Console.WriteLine(tld.Name));
            Console.ReadLine();
        }
    }
}
