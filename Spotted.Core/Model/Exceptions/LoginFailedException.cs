using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Spotted.Core.Model.Exceptions
{
    class LoginFailedException : MobileServiceException
    {
        public LoginFailedException(HttpResponseMessage response) : base(response)
        {
        }
    }
}
