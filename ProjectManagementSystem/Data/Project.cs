using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Data
{
    public class Project
    {
        public String ProjectCode { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public User[] UsersAssigned { get; set; }

    }
}
