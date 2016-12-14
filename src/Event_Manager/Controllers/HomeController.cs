using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Event_Manager.Models;
using Event_Manager.Data;
using Microsoft.AspNetCore.Identity;

namespace Event_Manager.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        public IActionResult Index(String searchString, String sort)
        {
            if (searchString != null)
            {
                var events = from m in _context.Event
                             select m;
                if (!String.IsNullOrEmpty(searchString))
                {
                    events = events.Where(s => s.Name.Contains(searchString) || s.location.Contains(searchString) || s.genre.Contains(searchString) || s.EventName.Contains(searchString)); //return album

                }
                return View(events);
            }

            if (sort != null)
            {
                string artistName = "";
                string currentUserName = _userManager.GetUserName(User);
                foreach (ApplicationUser user in _userManager.Users)
                {
                    if (user.UserName == currentUserName)
                    {
                        artistName = user.Name;
                        var events = from m in _context.Event
                                     select m;
                        events = events.Where(s => s.EventName.Contains(artistName));
                        return View(events);
                    }
                }
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                var events = from m in _context.Event
                             select m;
                return View(events);
            }

            {
                //var eventList = _context.Event;

                //return View(eventList);

            }
        }




        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
