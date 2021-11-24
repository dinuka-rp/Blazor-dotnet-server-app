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

    public class ApplicationUser : IdentityUser
    {
        // user ID from AspNetUser table.
        //[Key]
        //public String OwnerID { get; set; }

        [Required][PersonalData]
        public String FirstName { get; set; }
        [PersonalData]
        public String LastName { get; set; }

        // public UserRoleEnum UserRole { get; set; }      // TODO: Add this to Identity Server from Registration - allow Admins to Edit

        // HACK: keep this separated from Identity Server? - not required there
        public List<Project> Projects { get; set; } 
        public List<Ticket> Tickets { get; set; }
    }
}
