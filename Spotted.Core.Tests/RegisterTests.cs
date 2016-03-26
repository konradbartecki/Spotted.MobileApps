using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotted.Model.Entities;
using Spotted.Model.Requests;

namespace Spotted.Core.Tests
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
                Sex = (User.Sex)r.Next(2)
            };
        }

        [TestMethod]
        public async Task<RegisterRequest> RegisterNewAccount()
        {
            using (var service = Config.GetMobileService())
            {
                var freshAccount = GetRandomRegisterRequest();
                await service.Register(freshAccount);
                return freshAccount;
            }
        }


    }
}
