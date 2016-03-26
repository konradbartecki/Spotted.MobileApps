using System;
using System.Net.Http;
using System.Threading.Tasks;
using Spotted.MobileServiceProxy.Exceptions;
using Spotted.MobileServiceProxy.Extensions;
using Spotted.Model.Enums;
using Spotted.Model.Responses;

namespace Spotted.MobileServiceProxy.Helpers
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
                case ApiErrors.LoginFailed:
                    return new LoginFailedException(response);
                //case CustomErrors.EmailExists:
                //    break;
                default:
                    return new MobileServiceException(response);
            }
        }
    }
}
