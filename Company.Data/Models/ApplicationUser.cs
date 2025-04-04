using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Models
{
    [Keyless]
    public class ApplicationUser:IdentityUser
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

    }
}
