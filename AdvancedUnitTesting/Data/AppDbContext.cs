using AdvancedUnitTesting.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdvancedUnitTesting.Data
{
	public class AppDbContext : DbContext
	{

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>()
				.HasOne(o => o.User)
				.WithMany(u => u.Orders)
				.HasForeignKey(o => o.UserId);

			base.OnModelCreating(modelBuilder);
		}

	}

}

