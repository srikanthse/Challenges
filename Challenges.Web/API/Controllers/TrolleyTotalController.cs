using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Challenges.API.Request;
using Challenges.API.RequestValidator;
using Challenges.Application.Services;

namespace Challenges.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrolleyTotalController : ControllerBase
    {
        private readonly ITrolleyTotalRequestValidator _trolleyTotalRequestValidator;
        private readonly ITrolleyTotalCalculatorService _trolleyTotalCalculatorService;

        public TrolleyTotalController(ITrolleyTotalRequestValidator trolleyTotalRequestValidator,
            ITrolleyTotalCalculatorService trolleyTotalCalculatorService)
        {
            _trolleyTotalRequestValidator = trolleyTotalRequestValidator;
            _trolleyTotalCalculatorService = trolleyTotalCalculatorService;
        }

        [HttpPost]
        public async Task<ActionResult<decimal>> PostTrolleyTotal(TrolleyTotalRequest request)
        {
            var validationErrors = _trolleyTotalRequestValidator.Validate(request);
            if (validationErrors.Any())
            {
                return BadRequest(validationErrors);
            }

            var trolleyTotalCount = await _trolleyTotalCalculatorService.GetTrolleyTotal(request);
            return Ok(trolleyTotalCount);
        }

        [HttpPost("Custom")]
        public async Task<ActionResult<decimal>> CalculateTrolleyTotal(TrolleyTotalRequest request)
        {
            var validationErrors = _trolleyTotalRequestValidator.Validate(request);
            if (validationErrors.Any())
            {
                return BadRequest(validationErrors);
            }

            var trolleyTotalCount = await _trolleyTotalCalculatorService.GetTrolleyTotalCustom(request);
            return Ok(trolleyTotalCount);
        }
    }
}
