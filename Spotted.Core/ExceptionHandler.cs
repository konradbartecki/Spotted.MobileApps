using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Spotted.Core.Extensions;
using Spotted.Core.Model.Enums;
using Spotted.Core.Model.Exceptions;
using Spotted.Core.Model.Responses;

namespace Spotted.Core
{
    public static class ExceptionHandler
    {
        public static async Task<Exception> FromResponseAsync(HttpResponseMessage response)
        {
            var errorResponse = await response.Content.ReadAsAsync<StatusResponse>();

            switch (errorResponse.status)
            {
                //case CustomErrors.TokenInvalid:
                //    break;
                case CustomErrors.LoginFailed:
                    return new LoginFailedException(response);
                //case CustomErrors.EmailExists:
                //    break;
                default:
                    return new MobileServiceException(response);
            }
        }
    }
}
