using System;
using System.Collections.Generic;
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
        public User(string name)
        {
            Name = name;
        }
        // TODO: generate a constructor that takes in all the required fields
        // TODO: add null checks

        public String Name { get; set; }

        public String Username { get; set; }

        // public String Password { get; set; }        // TODO: check if this is necessary (since identity server takes care of it & this information shouldn't be visible to the frontend)

        public UserRoleEnum UserRole { get; set; }
    }
}
