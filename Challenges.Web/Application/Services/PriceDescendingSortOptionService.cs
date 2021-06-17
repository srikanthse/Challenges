using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenges.Application.Domain;

namespace Challenges.Application.Services
{
    public class PriceDescendingSortOptionService : ISortOptionService
    {
        public async Task<IEnumerable<Product>> GetSortedProducts(IEnumerable<Product> productsList)
        {
            var sortedProducts = await Task.FromResult(productsList.OrderByDescending(x => x.Price));
            return sortedProducts;
        }
    }
}
