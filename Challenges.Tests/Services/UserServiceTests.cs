using System.Threading.Tasks;
using NUnit.Framework;
using Challenges.Application.Services;
using Challenges.Application.Utils;

namespace Challenges.Tests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private IUserService _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new UserService();
        }

        [Test]
        public async Task ItShouldGetUserDetails()
        {
            var userDetails = await _sut.GetUserDetails();

            Assert.AreEqual(userDetails.Name, Constants.DevName);
            Assert.AreEqual(userDetails.Token, Constants.Token);
        }
    }
}
