using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Data
{
    public enum UserRoleEnum
    {
        Developer,
        Admin,
    }

    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public String Name { get; set; }

        public String Username { get; set; }

        // public String Password { get; set; }        // TODO: check if this is necessary (since identity server takes care of it & this information shouldn't be visible to the frontend)

        [Required]
        public UserRoleEnum UserRole { get; set; }      // TODO: Add this to Identity Server

        public List<Project> ProjectsAssignedTo { get; set; }       // HACK: keep this separated from Identity Server? - not required there
        public List<Ticket> TicketsAssignedTo { get; set; }
    }
}
