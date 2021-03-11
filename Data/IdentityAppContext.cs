using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WadoRyu.Models;

namespace WadoRyu.Data
{
	public class IdentityAppContext : IdentityDbContext<AppUser, AppRole, int>
	{

	}
}
