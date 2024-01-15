using Microsoft.AspNetCore.Identity;

namespace MoviesWebApi.Infrastructure
{
    public class ApplicationUser : IdentityUser
    {
        // Additional properties or customization, if needed
        public string MiUsuarioGuapo { get; set; }
    }

}
