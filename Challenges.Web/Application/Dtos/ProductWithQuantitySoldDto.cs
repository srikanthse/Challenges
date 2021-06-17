using Challenges.Application.Domain;

namespace Challenges.Application.Dtos
{
    public class ProductWithQuantitySoldDto
    {
        public Product Product { get; set; }
        public long QuantitySold { get; set; }
    }
}
