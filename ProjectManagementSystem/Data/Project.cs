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
        public String ProjectCode { get; set; }

        [Required]
        public String Name { get; set; }

        public String Description { get; set; }

        public List<User> UsersAssigned { get; set; }
    }
}
