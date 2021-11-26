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
        [Required][PersonalData]
        public String FirstName { get; set; }
        [PersonalData]
        public String LastName { get; set; }

        // public UserRoleEnum UserRole { get; set; }      // TODO: Add this to Identity Server from Registration - allow Admins to Edit

        public List<Project> Projects { get; set; } 
        public List<Ticket> Tickets { get; set; }
    }
}
