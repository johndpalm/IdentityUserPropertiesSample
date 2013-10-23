using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySample.Models
{
    public class GuestListViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string FullName { get { return (FirstName + " " + LastName); } }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Joined")]
        public DateTime JoinDate { get; set; }

        public ICollection<IdentityUserLogin> Logins { get; set; }
    }

}
