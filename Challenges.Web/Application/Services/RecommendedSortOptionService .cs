using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenges.Application.Domain;
using Challenges.Application.Dtos;
using Challenges.Application.HttpClientWrapper;
using Challenges.Application.Utils;

namespace Challenges.Application.Services
{
    public class RecommendedSortOptionService : ISortOptionService
    {
        private readonly IChallengesHttpClient _ChallengesHttpClient;

        public RecommendedSortOptionService(IChallengesHttpClient ChallengesHttpClient)
        {
            _ChallengesHttpClient = ChallengesHttpClient;
        }
        public async Task<IEnumerable<Product>> GetSortedProducts(IEnumerable<Product> productsList)
        {
            var shopperHistories = await GetShoppingHistories();
            var sortedProducts = SortProductsBasedOnPopularity(productsList, shopperHistories);
            return sortedProducts;
        }

        private IEnumerable<Product> SortProductsBasedOnPopularity(IEnumerable<Product> productsList, 
            IEnumerable<ShopperHistory> shopperHistories)
        {
            var productWithQuantitySoldDict = new Dictionary<string, ProductWithQuantitySoldDto>();

            foreach (var shopperHistory in shopperHistories)
            {
                foreach (var soldProduct in shopperHistory.Products)
                {
                    if (!productWithQuantitySoldDict.ContainsKey(soldProduct.Name))
                    {
                        productWithQuantitySoldDict[soldProduct.Name] = new ProductWithQuantitySoldDto
                        {
                            Product = productsList.Single(p=> p.Name.Equals(soldProduct.Name)),
                            QuantitySold = soldProduct.Quantity
                        };
                    }
                    else
                    {
                        productWithQuantitySoldDict[soldProduct.Name].QuantitySold += soldProduct.Quantity;
                    }
                }
            }

            var popularProducts =  productWithQuantitySoldDict.Values.ToList()
                .OrderByDescending(p => p.QuantitySold).Select(p => p.Product).ToList();

            foreach (var product in productsList)
            {
                if (popularProducts.All(p => p.Name != product.Name))
                    popularProducts.Add(product);
            }

            return popularProducts;
        }

        private async Task<IEnumerable<ShopperHistory>> GetShoppingHistories()
        {
            var shopperHistories = await _ChallengesHttpClient.GetAsync<IEnumerable<ShopperHistory>>(Constants.ShopperHistoryUri);
            return shopperHistories;
        }
    }
}
