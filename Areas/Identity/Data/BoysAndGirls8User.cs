using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BoysAndGirls8.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the BoysAndGirls8User class
    public class BoysAndGirls8User : IdentityUser
    {
        public string Name { get; set; }
    }
}
