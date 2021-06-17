using System.Collections.Generic;
using System.Threading.Tasks;
using Challenges.Application.Domain;

namespace Challenges.Application.Services
{
    public interface ISortOptionService
    {
        Task<IEnumerable<Product>> GetSortedProducts(IEnumerable<Product> productsList);
    }
}
