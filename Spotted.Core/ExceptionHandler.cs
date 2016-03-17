using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Spotted.Core
{
    public static class ExceptionHandler
    {
        public static Task<Exception> FromResponseAsync(HttpResponseMessage response)
        {
            throw new NotImplementedException();
        }
    }
}
