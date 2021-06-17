using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Challenges.Application.Domain;
using Challenges.Application.HttpClientWrapper;
using Challenges.Application.Services;

namespace Challenges.Tests.Services
{
    [TestFixture]
    public class RecommendedSortOptionServiceTests
    {
        private RecommendedSortOptionService _sut;
        private Mock<IChallengesHttpClient> _ChallengesHttpClientMock;

        [SetUp]
        public void SetUp()
        {
            _ChallengesHttpClientMock = new Mock<IChallengesHttpClient>();
             _sut = new RecommendedSortOptionService(_ChallengesHttpClientMock.Object);
        }

        [Test]
        public async Task IsShouldSortProductsByPopularity()
        {
            const int zeroQuantity = 0;
            _ChallengesHttpClientMock.Setup(m => m.GetAsync<IEnumerable<ShopperHistory>>(It.IsAny<string>()))
                .Returns(TestData.GetTestShopperHistory);

            var productList = await TestData.GetTestProducts();
            var sortedProducts = await _sut.GetSortedProducts(productList);

            var actualProductListArray = sortedProducts.ToArray();
            Assert.AreEqual(TestData.TestProduct2, actualProductListArray[0].Name);
            Assert.AreEqual(TestData.HighestPrice, actualProductListArray[0].Price);
            Assert.AreEqual(TestData.TestProduct1, actualProductListArray[1].Name);
            Assert.AreEqual(TestData.LowestPrice, actualProductListArray[1].Price);
            Assert.AreEqual(zeroQuantity, actualProductListArray[0].Quantity);
            Assert.AreEqual(zeroQuantity, actualProductListArray[1].Quantity);
        }
    }
}
