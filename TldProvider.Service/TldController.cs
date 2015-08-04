using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TldProvider.Core;

namespace TldProvider.Service
{
    public class TldController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string supportedTLDPage = ConfigurationManager.AppSettings["AWS-URL"];
            var tldProvider = new TldListProvider();
            var tldList = tldProvider.GetSupportedTldList(supportedTLDPage);
            var output = new {
                url = supportedTLDPage, 
                date = DateTime.UtcNow.ToString(),
                tldList = tldList.Select(tld => tld.Name)
            };
            return this.Request.CreateResponse(HttpStatusCode.OK, output);
        }
    }
}
