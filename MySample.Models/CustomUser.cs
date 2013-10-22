using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace MySample.Models
{
    public class CustomUser : IdentityUser
    {
        public CustomUser() : base() 
        {
            JoinDate = DateTime.Now;
        }
        public CustomUser(string username) : base(username) 
        {
            JoinDate = DateTime.Now;
        }

        public DateTime JoinDate { get; private set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get { return (FirstName + " " + LastName); } }

        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
