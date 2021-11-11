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

        public Report GenerateReport(DateTime startDate , DateTime endDate ) 
        {
            // TODO: call DB & return created Report
            Report report = new Report();
            return report;
        }
    }
}
