using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

// TODO: check if this is needed for the db to work

namespace ProjectManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // naming convention shifts from normal SQL (table names in singular -> plural form) to support limitations in EF
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
