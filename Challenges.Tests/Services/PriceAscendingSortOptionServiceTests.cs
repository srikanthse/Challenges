using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Challenges.Application.Services;

namespace Challenges.Tests.Services
{
    [TestFixture]
    public class PriceAscendingSortOptionServiceTests
    {
        private PriceAscendingSortOptionService _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new PriceAscendingSortOptionService();
        }

        [Test]
        public async Task IsShouldSortProductsAscendingOrderByPrice()
        {
            var productList = await TestData.GetTestProducts();
            var sortedProducts = await _sut.GetSortedProducts(productList);

            var actualProductListArray = sortedProducts.ToArray();
            Assert.AreEqual(TestData.LowestPrice, actualProductListArray[0].Price);
            Assert.AreEqual(TestData.HighestPrice, actualProductListArray[1].Price);
        }
    }
}
