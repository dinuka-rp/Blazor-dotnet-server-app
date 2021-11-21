using ProjectManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Use Linq here or in the Service? - to assign tickets to users

namespace ProjectManagementSystem.Controllers
{
    public class TicketController
    {
        #region Property
        private readonly TicketService _ticketService;
        #endregion

        #region Constructor
        public TicketController( TicketService ticketService)
        {
            _ticketService = ticketService;
        }
        #endregion

        // This is usually where the GET/ POST/ PUT/ PATCH/ DELETE requests are mapped to functions that handle respective services.

        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            return await _ticketService.GetAllTicketsAsync();
        }
    }
}
