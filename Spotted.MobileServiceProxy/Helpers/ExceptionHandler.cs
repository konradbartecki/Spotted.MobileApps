using System;
using System.Net.Http;
using System.Threading.Tasks;
using Spotted.MobileServiceProxy.Exceptions;
using Spotted.MobileServiceProxy.Extensions;
using Spotted.Model.Enums;
using Spotted.Model.Responses;

namespace Spotted.MobileServiceProxy.Helpers
{
    internal static class ExceptionHandler
    {
        public static async Task<Exception> FromResponseAsync(HttpResponseMessage response)
        {
            var errorResponse = await response.Content.ReadAsAsync<StatusResponse>();

            switch (errorResponse.status)
            {
                //case CustomErrors.TokenInvalid:
                //    break;
                case ApiErrors.LoginFailed:
                    return new LoginFailedException(errorResponse.status.ToString());
                case ApiErrors.EmailExists:
                    return new AccountAlreadyRegisteredException(errorResponse.ToString());
                default:
                    return new MobileServiceException(response);
            }
        }
    }
}
