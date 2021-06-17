using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Challenges.Application.Domain;
using Challenges.Application.Services;
using Challenges.Application.Utils;

namespace Challenges.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("sort")]
        public async Task<ActionResult<IEnumerable<Product>>> GetSortedProducts(SortOption sortOption)
        {
            var sortedProducts = await _productService.GetSortedProducts(sortOption);
            return Ok(sortedProducts);
        }
    }
}
