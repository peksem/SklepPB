using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SklepPB.Models.Users;

namespace SklepPB.DAL
{
    public class AccountsContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AccountsContext(DbContextOptions<AccountsContext> options) : base(options)
        {
        }

        protected AccountsContext()
        {
        }
    }
}
