using Microsoft.AspNetCore.Identity;

namespace AECProject.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }
}
