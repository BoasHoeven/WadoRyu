using Microsoft.AspNetCore.Identity;

namespace WadoRyu.Models
{
	public class ApplicationUser : IdentityUser<string>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
