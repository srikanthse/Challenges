using System.Collections.Generic;
using System.Threading.Tasks;
using Challenges.Application.Domain;
using Challenges.Application.HttpClientWrapper;
using Challenges.Application.Utils;

namespace Challenges.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IChallengesHttpClient _ChallengesHttpClient;
        private readonly ISortOptionFactory _sortOptionOptionFactory;

        public ProductService(IChallengesHttpClient ChallengesHttpClient, ISortOptionFactory sortOptionOptionFactory)
        {
            _ChallengesHttpClient = ChallengesHttpClient;
            _sortOptionOptionFactory = sortOptionOptionFactory;
        }

        public async Task<IEnumerable<Product>> GetSortedProducts(SortOption sortOption)
        {
            var productList = await GetProducts();
            var sortedProducts = await _sortOptionOptionFactory.GetSortingServiceInstance(sortOption).GetSortedProducts(productList);
            return sortedProducts;
        }

        private async Task<IEnumerable<Product>> GetProducts()
        {
            var productList = await _ChallengesHttpClient.GetAsync<IEnumerable<Product>>(Constants.ProductUri);
            return productList;
        }
    }
}
