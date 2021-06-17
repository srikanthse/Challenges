using System.Collections.Generic;
using System.Linq;

namespace Challenges.Application.Dtos
{
    public class SpecialDto
    {
        public SpecialDto()
        {
            ProductWithSpecials = new List<ProductWithSpecialDto>();
        }

        public IList<ProductWithSpecialDto> ProductWithSpecials { get; set; }
        public decimal SpecialPrice { get; set; }
        public long TotalSpecialQuantity { get; set; }
        public long TotalSelectedQuantity { get; set; }
        public decimal FinalPrice { get; set; }
        internal void ComputeFinalPrice()
        {
            var quantityFactor = TotalSelectedQuantity / TotalSpecialQuantity;

            if (TotalSelectedQuantity < TotalSpecialQuantity
                || ProductWithSpecials.Any(p => p.SelectedQuantity < p.SpecialQuantity))
            {
                FinalPrice = ProductWithSpecials.Sum(p => (p.ProductStandardPrice * p.SelectedQuantity));
            }
            else if ((TotalSelectedQuantity >= TotalSpecialQuantity) &&
                     (TotalSelectedQuantity % TotalSpecialQuantity == 0))
            {
                FinalPrice = quantityFactor * SpecialPrice;
            }
            else if ((TotalSelectedQuantity >= TotalSpecialQuantity) &&
                     (TotalSelectedQuantity % TotalSpecialQuantity != 0))
            {
                FinalPrice = quantityFactor * SpecialPrice + ProductWithSpecials.Sum(p => GetComputedValue(p, quantityFactor));
            }
        }

        private decimal GetComputedValue(ProductWithSpecialDto product, long quantityFactor)
        {
            if (product.SelectedQuantity < (quantityFactor * product.SpecialQuantity))
                return (product.SelectedQuantity - product.SpecialQuantity) * product.ProductStandardPrice;
            return (product.SelectedQuantity - (quantityFactor * product.SpecialQuantity)) * product.ProductStandardPrice;
        }
    }
}
