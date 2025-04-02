using System.Security.Claims;
using eCommerceApp.Domain.Entities.Identity;
using eCommerceApp.Domain.Interfaces.Authentication;
using eCommerceApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Infrastructure.Repositories.Authentication
{
	public class UserManagement(IRoleManagement roleManagement,
		UserManager<AppUser> userManager,
		AppDbContext dbContext) : IUserManagement
	{
		public async Task<bool> CreateUser(AppUser user)
		{
			AppUser? _user = await GetUserByEmail(user.Email!);
			if (_user != null) return false;

			return (await userManager.CreateAsync(user!, user!.PasswordHash!)).Succeeded;
		}

		public async Task<IEnumerable<AppUser>?> GetAllUsers() => await dbContext.Users.ToListAsync();

		public async Task<AppUser?> GetUserByEmail(string email) => await userManager.FindByEmailAsync(email);

		public async Task<AppUser> GetUserById(string id)
		{
			var user = await userManager.FindByIdAsync(id);
			return user!;
		}

		public async Task<List<Claim>> GetUserClaims(string email)
		{
			Console.WriteLine($"Fetching claims for email: {email}");

			var _user = await GetUserByEmail(email);

			if (_user is null) Console.WriteLine($"No email found for: {email}");

			string? roleName = await roleManagement.GetUserRole(_user!.Email!);

			if (string.IsNullOrEmpty(roleName))
			{
				Console.WriteLine($"No role found for user: {email}");
				roleName = "User"; // Fallback role or handle appropriately
			}

			List<Claim> claims = [
	new Claim("FullName", _user!.FullName ?? ""),
	new Claim(ClaimTypes.NameIdentifier, _user!.Id ?? ""),
	new Claim(ClaimTypes.Email, _user!.Email ?? ""),
	new Claim(ClaimTypes.Role, roleName ?? "Unknown")
];

			return claims;
		}

		public async Task<bool> LoginUser(AppUser user)
		{
			var _user = await GetUserByEmail(user.Email!);
			if (_user is null) return false;

			string? roleName = await roleManagement.GetUserRole(_user!.Email!);
			if (string.IsNullOrEmpty(roleName)) return false;

			return await userManager.CheckPasswordAsync(_user, user.PasswordHash!);
		}

		public async Task<int> RemoveUserByEmail(string email)
		{
			var user = await dbContext.Users.FirstOrDefaultAsync(_ => _.Email == email);
			dbContext.Users.Remove(user!);
			return await dbContext.SaveChangesAsync();
		}
	}
}
