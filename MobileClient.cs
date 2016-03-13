using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using Newtonsoft.Json;
using Spotted.Core.Model;
using Spotted.Core.Model.Enums;
using Spotted.Core.Model.Interfaces;

namespace Spotted.Core
{
    public class MobileClient : HttpClient
    {
        public string Token { get; set; }

        private string apiVersion = Config.MobileService.ApiVersion;

        private string route = "api/{0}/{1}/{2}";

        private string UserController = "user";

        private IUserNotifier Notifier;


        public MobileClient(string address, IUserNotifier notifier)
        {
            this.BaseAddress = new Uri(address);
            this.Notifier = notifier;

        }

        public override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var status = JsonConvert.DeserializeObject<ResponseStatus>(content);
                //Notifier?.NotifyError(GetMessage(status.status));
            }
            return response;
        }

        public async Task<object> LoginAsync(string email, string password)
        {
             var response = await this.PostFormAsync(Url(UserController, "login"), new Dictionary<string, string>()
            {
                 ["email"] = email,
                 ["password"] = password
            });
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<object> RegisterAsync()
        {
            return null;
        }

        private string Url(string controller, string action)
        {
            return String.Format(route, apiVersion, controller, action);
        }

        private async Task<HttpResponseMessage> PostFormAsync(string url, Dictionary<string, string> formData)
        {
            using (var content = new FormUrlEncodedContent(formData))
            {
                return await this.PostAsync(url, content);
            }
        }

        private string GetMessage(CustomErrors error)
        {
            var errorToString = new Dictionary<CustomErrors, string>()
            {
                [CustomErrors.EmailExists] = "Email already assigned to an account",
                [CustomErrors.IncorrectEmailOrPassword] = "Email or password does not match"
            };

            return errorToString[error];
        }

    }
}
