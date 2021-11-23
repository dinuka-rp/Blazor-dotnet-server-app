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
        public Int64 Id { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        public TicketStatus Status { get; set; }

        public User UserAssigned { get; set; }
    }
}
