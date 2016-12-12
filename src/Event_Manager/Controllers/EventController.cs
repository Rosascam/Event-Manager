using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Event_Manager.Models;


namespace Event_Manager.Controllers
{
    public class EventController : Controller
    {

        private readonly ApplicationUser _context;

        public EventController(ApplicationUser context)
        {
            _context = context;
        }


        public IActionResult Create()
        {
            return View();
           
        }
    }
}
