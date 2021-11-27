using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProjectManagementSystem.Data
{
    public enum UserRoleEnum
    {
        Developer,
        Admin,
    }
    //UserRole { get; set; }      // TODO: allow Admins to Edit this from Users view - by default, no user-role will be given
    // change this directly in the database?

    public class ApplicationUser : IdentityUser
    {
        // TODO: Add string character limits for data in all places
        [Required][PersonalData]
        public String FirstName { get; set; }
        [PersonalData]
        public String LastName { get; set; }

        public List<Project> Projects { get; set; } 
        public List<Ticket> Tickets { get; set; }
    }
}
