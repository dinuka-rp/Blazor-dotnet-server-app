using ProjectManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Shared.DTOs
{
    public class ReportDTO
    {
        public List<Project> CompletedProjects { get; set; }
        public List<Ticket> CompletedTickets { get; set; }
    }
}
