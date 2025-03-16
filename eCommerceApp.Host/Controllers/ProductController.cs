using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Host.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController(IProductService productService) : ControllerBase
	{
	}
}
