using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Challenges.Application.Services;

namespace Challenges.Tests.Services
{
    [TestFixture]
    public class NameDescendingSortOptionServiceTests
    {
        private NameDescendingSortOptionService _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new NameDescendingSortOptionService();
        }

        [Test]
        public async Task IsShouldSortProductsDescendingOrderByName()
        {
            var productList = await TestData.GetTestProducts();
            var sortedProducts = await _sut.GetSortedProducts(productList);

            var actualProductListArray = sortedProducts.ToArray();
            Assert.AreEqual(TestData.TestProduct2, actualProductListArray[0].Name);
            Assert.AreEqual(TestData.TestProduct1, actualProductListArray[1].Name);
        }
    }
}
