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
    // TODO: allow Admins to Edit this from Users view - by default, no user-role will be given

    public class ApplicationUser : IdentityUser
    {
        [Required][PersonalData]
        [StringLength(15)]
        public String FirstName { get; set; }

        [PersonalData]
        [StringLength(25)]
        public String LastName { get; set; }

        public List<Project> Projects { get; set; } 
        public List<Ticket> Tickets { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }

    }
}
