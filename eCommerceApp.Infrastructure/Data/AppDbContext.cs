using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.Cart;
using eCommerceApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Infrastructure.Data
{
	public class AppDbContext : IdentityDbContext<AppUser>
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<RefreshToken> RefreshToken { get; set; }
		public DbSet<PaymentMethod> PaymentMethods { get; set; }
		public DbSet<Archive> CheckoutArchive { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<PaymentMethod>()
				.HasData(
					new PaymentMethod
					{
						Id = Guid.NewGuid(),
						Name = "Credit Card", 
					}
				);

			builder.Entity<IdentityRole>()
				.HasData(
					new IdentityRole
					{
						Id = "6A1EBD8E-8F3A-4B2E-BE41-3D56B21739D5", // Hardcoded GUID
						Name = "Admin",
						NormalizedName = "ADMIN"
					},
					new IdentityRole
					{
						Id = "F5A8B4E7-75C9-4D9B-8C12-3F89A3EF6D9D", // Hardcoded GUID
						Name = "User",
						NormalizedName = "USER"
					}
				);
		}
	}
}
