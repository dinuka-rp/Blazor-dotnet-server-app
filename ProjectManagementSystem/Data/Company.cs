using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Data
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public String Name { get; set; }
        public List<Project> ProjectsAssigned { get; set; }
    }
}
