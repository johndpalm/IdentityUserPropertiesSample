using Microsoft.AspNet.Identity.EntityFramework;
using MySample.Models;

namespace MySample.Data
{
    public class CustomDbContext : IdentityDbContext<CustomUser>
    {
        public CustomDbContext()
            : base("DefaultConnection")
        { }
    }
}
