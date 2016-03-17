using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spotted.Core.Extensions;
using Spotted.Core.Model;
using Spotted.Core.Model.Enums;
using Spotted.Core.Model.Interfaces;
using Spotted.Core.Model.Responses;
using Spotted.Core.Model.ServiceRequests;

namespace Spotted.Core
{
    public class MobileService : IDisposable
    {
        internal static class Names
        {
            internal static class AuthController
            {
                internal static readonly string Name = "auth";
                internal static readonly string LoginAction = "signin";
                internal static readonly string RegisterAction = "signup";
            }

            internal static class UsersController
            {
                internal static readonly string Name = "users";
            }

            internal static class PostsController
            {
                
            }
        }

        private readonly string _address;
        private HttpClient _client;
        private static string _accessToken;
        private HttpClient Client => _client ?? (_client = CreateClient());

        public string AccessToken
        {
            get { return _accessToken; }
            set
            {
                _accessToken = value;
                SetClientAuthentication(Client, value);
            }
        }

        public MobileService(string address)
        {
            _address = address;
        }

        private HttpClient CreateClient()
        {
            var client = new HttpClient() { BaseAddress = new Uri(_address) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            SetClientAuthentication(client, AccessToken);
            return client;
        }

        private void SetClientAuthentication(HttpClient client, string accessToken)
        {
            if (accessToken != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            else
            {
                client.DefaultRequestHeaders.Authorization = null;
            }
        }

        private string Url(string controller, string action)
        {
            return string.Format("/api/v1/{0}/{1}", controller, action);
        }



        /// <summary>
        /// Logs user in using email and password
        /// </summary>
        /// <returns>Bearer token</returns>
        public async Task<string> Login(LoginRequest request)
        {
            var response = await PostAsync<TokenResponse>(Url(Names.AuthController.Name, Names.AuthController.LoginAction), request);
            return response.Token;
        }
    
        public async Task<T> GetAsync<T>(string url)
        {
            var response = await Client.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<T>();
            else
                throw await ExceptionHandler.FromResponseAsync(response);
        }

        public async Task<T> PostAsync<T>(string url, object o)
        {
            if (o is IValidable)
            {
                var ov = (IValidable) o;
                ov.CheckValidity();
            }
            if (o is IDtoConvertable)
            {
                var ov = (IDtoConvertable) o;
                o = ov.AsDto();
            }
            var json = JsonConvert.SerializeObject(o);

            var response = await Client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<T>();
            else
                throw await ExceptionHandler.FromResponseAsync(response);
        }

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
