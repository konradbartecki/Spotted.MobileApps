using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotted.Core;
using Spotted.MobileServiceProxy.Exceptions;
using Spotted.Model.Requests;

namespace Spotted.MobileServiceProxy.Tests
{
    [TestClass]
    public class LoginTests
    {
        //[TestMethod]
        //public async Task Login_Success()
        //{
        //    using (var service = Config.GetMobileService())
        //    {
        //        var token = await service.Login(new LoginRequest()
        //        {
        //            Email = "asd@asd.pl",
        //            Password = "asdasd"
        //        });

        //        Trace.WriteLine(token);
        //        Assert.IsNotNull(string.IsNullOrWhiteSpace(token));
        //    }
        //}

        [TestMethod]
        public async Task Login_ToFreshAccount()
        {
            using (var service = Config.GetMobileService())
            {
                var acc = RegisterTests.GetRandomRegisterRequest();
                await service.Register(acc);
                Trace.WriteLine("Account created");
                Trace.WriteLine(acc.Email);
                Trace.WriteLine(acc.Password);
                Trace.WriteLine(acc.Gender);

                var token = await service.Login(new LoginRequest()
                {
                    Email = acc.Email,
                    Password = acc.Password
                });

                Trace.WriteLine(token);
                Assert.IsNotNull(string.IsNullOrWhiteSpace(token));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(LoginFailedException))]
        public async Task Login_UnknownPassword()
        {
            using (var service = Config.GetMobileService())
            {
                var token = await service.Login(new LoginRequest()
                {
                    Email = "konradbartecki@outlook.com",
                    Password = Guid.NewGuid().ToString()
                });
            }
        }

        [TestMethod]
        [ExpectedException(typeof(LoginFailedException))]
        public async Task Login_UnknownEmail()
        {
            using (var service = Config.GetMobileService())
            {
                var token = await service.Login(new LoginRequest()
                {
                    
                    Email = Guid.NewGuid().ToString(),
                    Password = "asdasd"
                });
            }
        }

        [TestMethod]
        [ExpectedException(typeof(LoginFailedException))]
        public async Task Login_EmptyLogin()
        {
            using (var service = Config.GetMobileService())
            {
                var token = await service.Login(new LoginRequest()
                {

                    Email = string.Empty,
                    Password = "asdasd"
                });
            }
        }

        [TestMethod]
        [ExpectedException(typeof(LoginFailedException))]
        public async Task Login_EmptyPassword()
        {
            using (var service = Config.GetMobileService())
            {
                var token = await service.Login(new LoginRequest()
                {

                    Email = "mail@mail.pl",
                    Password = string.Empty
                });
            }
        }


        [TestMethod]
        [ExpectedException(typeof(LoginFailedException))]
        public async Task Login_EmptyLoginAndPassword()
        {
            using (var service = Config.GetMobileService())
            {
                var token = await service.Login(new LoginRequest()
                {

                    Email = string.Empty,
                    Password = string.Empty
                });
            }
        }

        [TestMethod]
        [ExpectedException(typeof(LoginFailedException))]
        public async Task Login_NullLoginAndPassword()
        {
            using (var service = Config.GetMobileService())
            {
                var token = await service.Login(new LoginRequest()
                {

                    Email = null,
                    Password = null
                });
            }
        }
    }
}
