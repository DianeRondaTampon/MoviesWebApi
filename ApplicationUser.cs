using Microsoft.AspNetCore.Identity;

namespace MoviesWebApi
{
    public class ApplicationUser : IdentityUser
    {
        // Additional properties or customization, if needed
        public string Username { get; set; }
    }

}
