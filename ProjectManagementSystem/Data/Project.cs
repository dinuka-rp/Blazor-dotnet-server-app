using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Data
{
    public class Project
    {
        [Key]
        public Int16 Id { get; set; }

        [Required]
        public String ProjectCode { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String CompanyId { get; set; }
        public Company Company { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
