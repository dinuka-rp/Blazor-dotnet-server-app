using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// reference: https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key

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
        [Key]
        public Guid Id { get; set; }

        [Required]
        public String Description { get; set; }

        public TicketStatus Status { get; set; }

        public User UserAssigned { get; set; }


        // methods with CRUD options in DB
        /*public Boolean CreateTicket(description : String, assignees : User[], status : TicketStatus)
        {
            // TODO: call DB
            if (err != null)
            {
                return false;
            }
            else {
                return true;
            }
        }*/
    }
}
