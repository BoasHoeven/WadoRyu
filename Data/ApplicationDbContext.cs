using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WadoRyu.Models;

namespace JokesWebApp.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<JokesWebApp.Models.NewsArticle> NewsArticle { get; set; }

		public DbSet<WadoRyu.Models.Video> Video { get; set; }
	}
}
