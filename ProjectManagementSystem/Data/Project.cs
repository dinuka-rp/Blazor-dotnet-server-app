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
        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public String Code { get; set; }

        [StringLength(30)]
        public String Name { get; set; }

        [StringLength(50)]
        public String Description { get; set; }

        public Company Company { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public List<Ticket> Tickets { get; set; }       // this isn't exactly necessary -LINQ can be used to quert from Tickets side
    }
}
