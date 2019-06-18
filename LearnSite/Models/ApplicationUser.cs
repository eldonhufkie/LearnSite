using Microsoft.AspNetCore.Identity;

namespace LearnSite.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        // public bool isAdmin { get; set; }
    }
}