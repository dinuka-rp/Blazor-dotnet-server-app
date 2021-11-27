using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementSystem.Data;
// Use Linq here to assign tickets to users? better to have a separate AssignService because many assigns are there

namespace ProjectManagementSystem.Models
{
    public class TicketService
    {
        #region Property
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion

        #region Constructor
        public TicketService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #endregion

        #region Get List of Tickets
        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            return await _applicationDbContext.Tickets.ToListAsync();
        }
        #endregion

        #region Get List of Tickets - with pagination
        //public async Task<List<Ticket>> GetAllTicketsWithPaginationAsync()
        //{
        //    // TODO: add pagination
        //    return await _applicationDbContext.Tickets.ToListAsync();
        //}
        #endregion

        #region Insert Ticket
        public async Task<bool> InsertTicketAsync(Ticket ticket)
        {
            await _applicationDbContext.Tickets.AddAsync(ticket);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Ticket by Id
        public async Task<Ticket> GetTicketAsync(int Id)
        {
            Ticket employee = await _applicationDbContext.Tickets.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return employee;
        }
        #endregion

        #region Update Ticket
        public async Task<bool> UpdateTicketAsync(Ticket ticket)
        {
            _applicationDbContext.Tickets.Update(ticket);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Ticket
        public async Task<bool> DeleteTicketAsync(Ticket ticket)
        {
            _applicationDbContext.Remove(ticket);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
