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

    public class Ticket : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public String Description { get; set; }

        [Required]
        public TicketStatus Status { get; set; }

        public List<ApplicationUser> Users { get; set; }

        //TODO: make this a required field?
        public Project Project { get; set; }
    }
}
