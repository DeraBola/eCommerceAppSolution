
using eCommerceApp.Domain.Entities.Cart;

namespace eCommerceApp.Application.Services.Interfaces.Cart
{
	public interface ICartService
	{
		Task<int> SaveCheckoutHistory(IEnumerable<Archive> checkouts);
	}
}
