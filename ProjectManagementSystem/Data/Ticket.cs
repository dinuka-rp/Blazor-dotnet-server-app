using System;

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
        public Ticket(string id, string description, User[] assignees, TicketStatus status)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            // remove null check for Id - it's set from the system
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Assignees = assignees;
            // ?? throw new ArgumentNullException(nameof(assignees));
            Status = status;
        }

        // TODO: Change all variable types to String!!!
        public string Id { get; set; }

        public string Description { get; set; }

        public User[] Assignees { get; set; }

        public TicketStatus Status { get; set; }


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
