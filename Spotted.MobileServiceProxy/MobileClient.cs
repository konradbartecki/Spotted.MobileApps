using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spotted.MobileServiceProxy.Helpers;
using Spotted.Model.Requests;
using Spotted.Model.Responses;
using Spotted.MobileServiceProxy.Extensions;
using Spotted.Model.Entities;
using Spotted.Model.Interfaces;

namespace Spotted.MobileServiceProxy
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
                internal static readonly string Name = "posts";
            }

            internal static class GroupsController
            {
                internal static readonly string Name = "groups";
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
                if (client.DefaultRequestHeaders.Contains("x-access-token"))
                    client.DefaultRequestHeaders.Remove("x-access-token");
                client.DefaultRequestHeaders.Add("x-access-token", accessToken);
            }
            else
            {
                client.DefaultRequestHeaders.Authorization = null;
            }
        }

        private string Url(string controller, string action = "")
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
            this.AccessToken = response.Token;
            return response.Token;
        }

        public async Task Register(RegisterRequest request)
        {
            await PostAsync(Url(Names.AuthController.Name, Names.AuthController.RegisterAction), request);
        }

        public async Task<List<Post>> GetPosts()
        {
            return await GetAsync<List<Post>>(Url(Names.PostsController.Name));
        }

        public async Task<List<BasicGroup>> GetGroups()
        {
            return await GetAsync<List<BasicGroup>>(Url(Names.GroupsController.Name));
        }
    
        private async Task<T> GetAsync<T>(string url)
        {
            var response = await Client.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<T>();
            else
                throw await ExceptionHandler.FromResponseAsync(response);
        }

        private async Task<T> PostAsync<T>(string url, object o)
        {
            //if (o is IValidable)
            //{
            //    var ov = (IValidable) o;
            //    ov.CheckValidity();
            //}
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

        private async Task PostAsync(string url, object o)
        {
            if (o is IDtoConvertable)
            {
                var ov = (IDtoConvertable)o;
                o = ov.AsDto();
            }
            var json = JsonConvert.SerializeObject(o);

            var response = await Client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode)
                throw await ExceptionHandler.FromResponseAsync(response);
        }

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}