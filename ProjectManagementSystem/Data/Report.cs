using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Data
{
    public class Report
    {
        public Project[] CompletedProjects { get; set; }

        public Ticket[] CompletedTickets { get; set; }

    }
}
