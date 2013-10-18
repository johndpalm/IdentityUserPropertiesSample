using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace MySample.Models
{
    public class CustomUser : IdentityUser
    {
        public CustomUser() : base() { }
        public CustomUser(string username) : base(username) { }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get { return (FirstName + " " + LastName); } }

        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
