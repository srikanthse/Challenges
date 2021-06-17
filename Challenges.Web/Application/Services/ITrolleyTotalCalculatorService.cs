using System.Threading.Tasks;
using Challenges.API.Request;

namespace Challenges.Application.Services
{
    public interface ITrolleyTotalCalculatorService
    {
        Task<decimal> GetTrolleyTotal(TrolleyTotalRequest request);
        Task<decimal> GetTrolleyTotalCustom(TrolleyTotalRequest request);
    }
}
