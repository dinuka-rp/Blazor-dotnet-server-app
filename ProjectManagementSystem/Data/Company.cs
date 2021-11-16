using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Data
{
    public class Company
    {
        public String Name { get; set; }
        public Project[] ProjectsAssigned { get; set; }

    }
}
