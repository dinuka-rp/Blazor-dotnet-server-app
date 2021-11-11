using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Data
{
    public enum TicketStatus
    {
        Open,
        InProgress,
        Done,
        ToDo,
        UnderReview,
        Approved,
        Cancelled,
    }

    public class Ticket
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public User[] Assignees { get; set; }
        
        public TicketStatus Status { get; set; }

    }
}
