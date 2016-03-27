using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotted.Core;

namespace Spotted.MobileServiceProxy.Tests
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public async Task GetPosts()
        {
            var loginTests = new LoginTests();
            await loginTests.Login_ToFreshAccount();
            using (var service = Config.GetMobileService())
            {
                var posts = await service.GetPosts();

                ;
            }
        }
    }
}
