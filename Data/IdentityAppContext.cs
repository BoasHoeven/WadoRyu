using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WadoRyu.Models;

namespace WadoRyu.Data
{
	public class IdentityAppContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
	{
		public IdentityAppContext(DbContextOptions<IdentityAppContext> options) : base(options)
		{

		}
	}
}
