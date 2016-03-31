using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotted.Core
{
    public static class Config
    {
        public static MobileServiceProxy.MobileService GetMobileService()
        {
            return new MobileServiceProxy.MobileService(MobileService.Address);
        }
        public static class MobileService
        {
            public static string Address = "http://spotted.city/";
            public static string ApiVersion = "v1";
        }
    }
}
