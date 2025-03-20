using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Infrastructure.Data
{
	public class AppDbContext(DbContextOptions options) : DbContext(options)
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<RefreshToken> RefreshToken { get; set; }
		// public DbSet<AppUser> Users { get; set; }
	}
}
