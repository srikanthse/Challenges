using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Challenges.Application.Services;

namespace Challenges.Tests.Services
{
    [TestFixture]
    public class PriceDescendingSortOptionServiceTests
    {
        private PriceDescendingSortOptionService _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new PriceDescendingSortOptionService();
        }

        [Test]
        public async Task IsShouldSortProductsDescendingOrderByPrice()
        {
            var productList = await TestData.GetTestProducts();
            var sortedProducts = await _sut.GetSortedProducts(productList);

            var actualProductListArray = sortedProducts.ToArray();
            Assert.AreEqual(TestData.HighestPrice, actualProductListArray[0].Price);
            Assert.AreEqual(TestData.LowestPrice, actualProductListArray[1].Price);
        }
    }
}
