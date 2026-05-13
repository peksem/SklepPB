using Microsoft.AspNetCore.Identity;

namespace SklepPB.Models.Users
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
    }
}
