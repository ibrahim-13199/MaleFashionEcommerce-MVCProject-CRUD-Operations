using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MVCProject.Models
{
    public class ApplicationUser: IdentityUser
    {
       
        public string address { get; set; }
        public List<Order> orders { get; set; }
    }
}
