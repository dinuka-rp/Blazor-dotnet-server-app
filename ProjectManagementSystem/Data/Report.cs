﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Data
{
    public class Report
    {
        public List<Project> CompletedProjects { get; set; }

        public List<Ticket> CompletedTickets { get; set; }

        // TODO: move this into ReportController

        public Report GenerateReport(DateTime startDate , DateTime endDate ) 
        {
            // TODO: call DB & return created Report
            Report report = new Report();
            return report;
        }
    }
}
