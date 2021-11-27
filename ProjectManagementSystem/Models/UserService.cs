using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementSystem.Data;

namespace ProjectManagementSystem.Models
{
    public class UserService
    {
        #region Property
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion

        #region Constructor
        public UserService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #endregion

        #region Get List of Users
        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await _applicationDbContext.Users.ToListAsync();
        }
        #endregion

        #region Get List of Users - with pagination
        //public async Task<List<Ticket>> GetAllTicketsWithPaginationAsync()
        //{
        //    // TODO: add pagination
        //    return await _applicationDbContext.Tickets.ToListAsync();
        //}
        #endregion
    }
}
