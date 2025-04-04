
using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Cart;
using eCommerceApp.Domain.Entities.Cart;

namespace eCommerceApp.Application.Services.Interfaces.Cart
{
	public interface ICartService
	{
		Task<ServiceResponse> SaveCheckoutHistory(IEnumerable<CreateArchive> archives);
		Task<ServiceResponse> Checkout(Checkout checkout);
	}
}
