using System.Collections.Generic;
using System.Threading.Tasks;
using Challenges.Application.Domain;
using Challenges.Application.Utils;

namespace Challenges.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetSortedProducts(SortOption sortOption);
    }
}
