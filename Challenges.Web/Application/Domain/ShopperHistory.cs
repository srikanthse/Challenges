using System.Collections.Generic;

namespace Challenges.Application.Domain
{
    public class ShopperHistory
    {
        public ShopperHistory()
        {
            Products = new List<Product>();
        }
        public int CustomerId { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
