using MySample.Data;
using MySample.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MySample.MVC.Controllers
{
    [Authorize]
    public class GuestsController : Controller
    {
        //
        // GET: /Guests/
        public ActionResult Index()
        {
            using (CustomDbContext db = new CustomDbContext())
            {
                ViewBag.Title = "Guest List";
                var guestlist = GetGuestList();
                return View(guestlist);
            }
        }

        public List<GuestListViewModel> GetGuestList()
        {
            using (CustomDbContext db = new CustomDbContext())
            {
                var guests = from users in db.Users orderby users.JoinDate
                    select new GuestListViewModel { 
                        FirstName = users.FirstName, 
                        LastName = users.LastName,
                        JoinDate = users.JoinDate,
                        Logins = users.Logins
                    };

                return guests.ToList<GuestListViewModel>();
            }
        }
	}
}