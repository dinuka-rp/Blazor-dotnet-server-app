using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.Shared.DTOs;

namespace ProjectManagementSystem.Models
{
    public class ReportService
    {
        #region Property
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion

        #region Constructor
        public ReportService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #endregion

        #region Get Report for chosen date range
        public async Task<ReportDTO> GetReportWithDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            //use LINQ - to get required details here
            List<Ticket> tickets = await _applicationDbContext.Tickets.Where(ticket => startDate <= ticket.CompletedOn
                                   && ticket.CompletedOn <= endDate).Include(r => r.Users).ToListAsync();
            List<Project> projects = await _applicationDbContext.Projects.Where(project => startDate <= project.CompletedOn
                                   && project.CompletedOn <= endDate).ToListAsync();
            // limitation: time can't be truncanted in EF 5 (EF 6 is required https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbfunctions.truncatetime?view=entity-framework-6.2.0)

            //create report from returned details
            return new ReportDTO
            {
                CompletedProjects = projects,
                CompletedTickets = tickets
            };
        }
        #endregion
    }
}
