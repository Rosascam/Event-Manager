using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Event_Manager.Models;
using Microsoft.AspNetCore.Identity;
using Event_Manager.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Event_Manager.Controllers
{
    public class EventController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public EventController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
               
        //[Authorize(Roles = "ARTIST")]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "ARTIST")]
        public IActionResult Create(Event addNewEvent)
        {
            string eventName = "";
            string CurrentUserName = _userManager.GetUserName(User);
            foreach (ApplicationUser user in _userManager.Users)
            {
                if (user.UserName == CurrentUserName)
                {
                    eventName = user.Name;
                }
            }

            if (ModelState.IsValid)
            {
                addNewEvent.EventName = eventName;
                _context.Event.Add(addNewEvent);
                _context.SaveChanges();

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View();
        }

        [Authorize]

        public IActionResult ReadEvents(int? id)
        {

            Event e = _context.Event.SingleOrDefault(a => a.EventID == id);
            return View(e);
        }

        //[Authorize(Roles = "ARTIST")]
        public IActionResult Update(int? id)
        {

            Event e = _context.Event.SingleOrDefault(a => a.EventID == id);

            if (_userManager.GetUserName(User) == e.EventName)
            {
                return View(e);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        //[Authorize(Roles = "ARTIST")]
        public IActionResult Update(Event e)
        {
            string artistName = "";
            string currentUserName = _userManager.GetUserName(User);
            foreach (ApplicationUser user in _userManager.Users)
            {
                if (user.UserName == currentUserName)
                {
                    artistName = user.Name;
                }
            }
            if (ModelState.IsValid)
            {
                e.EventName = artistName;
                _context.Event.Update(e);
                _context.SaveChanges();
                return RedirectToAction(nameof(HomeController.Index), "Home");

            }
            return View();
        }

        //[Authorize(Roles = "ARTIST")]
        public IActionResult Delete(int? id)
        {
            Event e = _context.Event.SingleOrDefault(a => a.EventID == id);

            if (_userManager.GetUserName(User) == e.EventName)
            {
                return View(e);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


        [HttpPost]
        //[Authorize(Roles = "ARTIST")]
        public IActionResult Delete(Event e)
        {
            _context.Event.Remove(e);
            _context.SaveChanges();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}  
            

    

    

