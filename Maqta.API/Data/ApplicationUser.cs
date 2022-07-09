using Microsoft.AspNetCore.Identity;

namespace Maqta.API.Data
{
    public class ApplicationUser: IdentityUser
    {
        public string UserName { get; set; }
    }
}
