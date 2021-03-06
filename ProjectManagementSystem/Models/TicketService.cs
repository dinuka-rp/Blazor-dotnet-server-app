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
            return await _applicationDbContext.Tickets.Include(r => r.Project).Include(r => r.Users).ToListAsync();
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
            if (ticket.Status == TicketStatus.InProgress)
            {
                // in update, set this only if it hasn't been set before - because tickets can be reopened - the initial progress will be lost if not
                ticket.StartedOn = DateTime.UtcNow;
            }
            else if (ticket.Status == TicketStatus.Done)
            {
                ticket.CompletedOn = DateTime.UtcNow;
            }

            await _applicationDbContext.Tickets.AddAsync(ticket);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Ticket by Id
        public async Task<Ticket> GetTicketAsync(Guid Id)
        {
            Ticket ticket = await _applicationDbContext.Tickets.Include(r => r.Project)
                .Include(r => r.Users).ThenInclude(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(c => c.Id.Equals(Id));
                return ticket;
        }
        #endregion

        #region Update Ticket
        public async Task<bool> UpdateTicketAsync(Ticket ticket)
        {
            if (ticket.Status == TicketStatus.InProgress)
            {
                Ticket oldTicketInfo = await _applicationDbContext.Tickets.FirstOrDefaultAsync(c => c.Id.Equals(ticket.Id));

                if (oldTicketInfo.StartedOn != null)
                {
                    // set this only if it hasn't been set before - because tickets can be reopened - the initial progress will be lost if not
                    ticket.StartedOn = DateTime.UtcNow;
                }
            }
            else if (ticket.Status == TicketStatus.Done)
            {
                ticket.CompletedOn = DateTime.UtcNow;
            }

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
