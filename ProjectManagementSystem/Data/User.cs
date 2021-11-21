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

    // Hack: check how to customize User properly with User Roles
    public class User: IdentityUser
    {
        [Required]
        public String Name { get; set; }

        public String Username { get; set; }

        [Required]
        public UserRoleEnum UserRole { get; set; }      // TODO: Add this to Identity Server

        public List<Project> ProjectsAssignedTo { get; set; }       // HACK: keep this separated from Identity Server? - not required there
        public List<Ticket> TicketsAssignedTo { get; set; }
    }
}
