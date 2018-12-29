using Microsoft.AspNetCore.Identity;

namespace registration.DataContext
{
    public class AppUser :IdentityUser
    {
        public string Name { get; set; }
    }
}