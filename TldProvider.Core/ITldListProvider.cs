using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TldProvider.Core
{
    interface ITldListProvider
    {
        List<Tld> GetSupportedTldList(string url);
    }
}
