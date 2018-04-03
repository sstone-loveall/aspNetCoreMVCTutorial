using aspNetCoreMVCTutorial.Domain;
using Microsoft.EntityFrameworkCore;

namespace aspNetCoreMVCTutorial.Repository.EntityFramework
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Pie> Pies { get; set; }

		public DbSet<Feedback> Feedbacks { get; set; }
	}
}