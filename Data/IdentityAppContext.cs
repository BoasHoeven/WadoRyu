using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WadoRyu.Models;

namespace WadoRyu.Data
{
	public class IdentityAppContext : IdentityDbContext<AppUser, AppRole, int>
	{

	}
}
