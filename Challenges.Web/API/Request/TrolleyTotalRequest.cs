using System.Collections.Generic;
using Challenges.Application.Domain;

namespace Challenges.API.Request
{
    public class TrolleyTotalRequest
    {
        public List<Product> Products { get; set; }
        public List<Special> Specials { get; set; }
        public List<Product> Quantities { get; set; }
    }
}
