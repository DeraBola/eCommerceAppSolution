using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceApp.Domain.Entities.Identity;

namespace eCommerceApp.Domain.Interfaces.Authentication
{
	public interface IRoleManagement
	{
		Task<bool> AddUserToRole(AppUser user, string roleName);

		Task<string?> GetUserRole(string userEmail);
	}

}
