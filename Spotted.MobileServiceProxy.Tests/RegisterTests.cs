using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotted.Core;
using Spotted.Model.Enums;
using Spotted.Model.Requests;

namespace Spotted.MobileServiceProxy.Tests
{
    [TestClass]
    public class RegisterTests
    {
        public static RegisterRequest GetRandomRegisterRequest()
        {
            var password = Guid.NewGuid().ToString();
            Random r = new Random();
            return new RegisterRequest()
            {
                Email = Guid.NewGuid() + "@outlook.com",
                Password = password,
                ReenteredPassword = password,
                Gender = (Gender)r.Next(2)
            };
        }

        [TestMethod]
        public async Task RegisterNewAccount(RegisterRequest account = null)
        {
            using (var service = Config.GetMobileService())
            {
                account = account ?? GetRandomRegisterRequest();
                await service.Register(account);
            }
        }

        [TestMethod]
        public async Task RegisterAndLogin()
        {
            using (var service = Config.GetMobileService())
            {
                var freshAccount = GetRandomRegisterRequest();
                await RegisterNewAccount(freshAccount);
                string token = await service.Login(new LoginRequest(freshAccount.Email, freshAccount.Password));
                Assert.IsFalse(string.IsNullOrWhiteSpace(token));
            }
        }


    }
}
