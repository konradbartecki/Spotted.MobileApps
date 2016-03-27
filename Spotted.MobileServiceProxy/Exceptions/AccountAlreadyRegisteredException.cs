using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Spotted.MobileServiceProxy.Exceptions
{
    public class AccountAlreadyRegisteredException : MobileServiceException
    {
        public AccountAlreadyRegisteredException(HttpResponseMessage response) : base(response)
        {
        }

        public AccountAlreadyRegisteredException(string message) : base(message)
        {
        }
    }
}
