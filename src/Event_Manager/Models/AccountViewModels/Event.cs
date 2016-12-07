using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Event_Manager.Models
{
    public class Event
    {
        public DateTime date { get; set; }
        public DateTime time { get; set; }
        public string location { get; set; }

        public string genre { get; set; }
     
    }
}
