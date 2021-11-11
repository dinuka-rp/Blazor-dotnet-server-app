using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Data
{
    public class Project
    {
        public string ProjectCode { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public User[] UsersAssigned { get; set; }

    }
}
