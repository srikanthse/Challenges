using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Challenges.API.Request;
using Challenges.Application.HttpClientWrapper;
using Challenges.Application.Services;

namespace Challenges.Tests.Services
{
    [TestFixture]
    public class TrolleyTotalCalculatorServiceTests
    {
        private TrolleyTotalCalculatorService _sut;
        private Mock<IChallengesHttpClient> _ChallengesHttpClientMock;

        [SetUp]
        public void SetUp()
        {
            _ChallengesHttpClientMock = new Mock<IChallengesHttpClient>();
            _sut = new TrolleyTotalCalculatorService(_ChallengesHttpClientMock.Object);
        }

        [Test]
        public async Task IsShouldSortProductsAscendingOrderByName()
        {
            _ChallengesHttpClientMock.Setup(m =>
                    m.PostJsonAsync<TrolleyTotalRequest, decimal>(It.IsAny<string>(), It.IsAny<TrolleyTotalRequest>()))
                .Returns(() => Task.FromResult(TestData.TrolleySpecialPrice));

            var trolleyTotalRequestDto = await TestData.GetTestTrolleyTotalRequest();
            var trolleyTotal = await _sut.GetTrolleyTotal(trolleyTotalRequestDto);

            Assert.AreEqual(TestData.TrolleySpecialPrice, trolleyTotal);
        }
    }
}
