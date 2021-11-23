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

    public class User
    {
        // user ID from AspNetUser table.
        [Key]
        public String OwnerID { get; set; }

        [Required]
        public String FirstName { get; set; }
        public String LastName { get; set; }

        // Hack: check how to customize User properly with User Roles
        // public UserRoleEnum UserRole { get; set; }      // TODO: Add this to Identity Server from Registration - allow Admins to Edit

        // HACK: keep this separated from Identity Server? - not required there
        public List<Project> ProjectsAssignedTo { get; set; } 
        public List<Ticket> TicketsAssignedTo { get; set; }
    }
}
