using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenges.API.Request;
using Challenges.Application.Dtos;
using Challenges.Application.HttpClientWrapper;
using Challenges.Application.Utils;

namespace Challenges.Application.Services
{
    public class TrolleyTotalCalculatorService : ITrolleyTotalCalculatorService
    {
        private readonly IChallengesHttpClient _ChallengesHttpClient;

        public TrolleyTotalCalculatorService(IChallengesHttpClient ChallengesHttpClient)
        {
            _ChallengesHttpClient = ChallengesHttpClient;
        }

        public async Task<decimal> GetTrolleyTotal(TrolleyTotalRequest request)
        {
            var trolleyTotal = await _ChallengesHttpClient
                .PostJsonAsync<TrolleyTotalRequest, decimal>(Constants.TrolleyCalculatorUri, request);

            return trolleyTotal;
        }

        public async Task<decimal> GetTrolleyTotalCustom(TrolleyTotalRequest request)
        {
            return await Task.FromResult(ComputeProductWithSpecialDto(request));
        }

        private decimal ComputeProductWithSpecialDto(TrolleyTotalRequest request)
        {
            IList<SpecialDto> specials = new List<SpecialDto>();
            foreach (var specialOffer in request.Specials)
            {
                var special = new SpecialDto();
                foreach (var specialQuantity in specialOffer.Quantities)
                {
                    var productWithSpecial = new ProductWithSpecialDto
                    {
                        Name = specialQuantity.Name,
                        SpecialQuantity = specialQuantity.Quantity,
                        SelectedQuantity = request.Quantities.Single(p => p.Name == specialQuantity.Name).Quantity,
                        ProductStandardPrice = request.Products.Single(p => p.Name == specialQuantity.Name).Price
                    };
                    special.ProductWithSpecials.Add(productWithSpecial);
                }

                special.SpecialPrice = specialOffer.Total;
                special.TotalSelectedQuantity = special.ProductWithSpecials.Sum(p => p.SelectedQuantity);
                special.TotalSpecialQuantity = special.ProductWithSpecials.Sum(p => p.SpecialQuantity);
                special.ComputeFinalPrice();
                specials.Add(special);
            }
            return specials.Sum(s => s.FinalPrice);
        }
    }
}
