using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_Manager.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Event_Manager.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //public object Event { get; internal set; }
        public string Name { get; set; }

    
    }
}
