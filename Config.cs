﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotted.Core
{
    public static class Config
    {
        public static MobileClient Client;
        public static class MobileService
        {
            public static string Address = "http://46.101.158.111:3000/";
            public static string ApiVersion = "v1";
        }
    }
}
