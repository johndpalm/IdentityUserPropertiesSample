using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {  
        public ApplicationUser(): base() {}
        public ApplicationUser(string username): base(username){}

        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
    }
}