using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotted.Core;
using Spotted.MobileServiceProxy.Exceptions;
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

        [TestMethod]
        [ExpectedException(typeof(AccountAlreadyRegisteredException))]
        public async Task Register_AccountExists()
        {
            var freshAccount = GetRandomRegisterRequest();
            await RegisterNewAccount(freshAccount);
            await RegisterNewAccount(freshAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(LoginFailedException))]
        public async Task Register_AccountExists_ReplaceAccount()
        {
            var freshAccount = GetRandomRegisterRequest();
            await RegisterNewAccount(freshAccount);
            freshAccount.Password = Guid.NewGuid().ToString();
            try
            {
                await RegisterNewAccount(freshAccount);
            }
            catch
            {
            }

            using (var service = Config.GetMobileService())
            {
                await service.Login(new LoginRequest(freshAccount.Email, freshAccount.Password));
            }
        }


    }
}
