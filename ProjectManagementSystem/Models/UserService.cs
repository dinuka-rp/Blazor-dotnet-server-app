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
        //public async Task<List<ApplicationUser>> GetAllUsersWithPaginationAsync()
        //{
        //    // TODO: add pagination
        //    return await _applicationDbContext.Users.ToListAsync();
        //}
        #endregion

        #region Insert User
        public async Task<bool> InsertUserAsync(ApplicationUser user)
        {
            await _applicationDbContext.Users.AddAsync(user);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Ticket by Id
        public async Task<ApplicationUser> GetUserAsync(String Id)
        {
            ApplicationUser user = await _applicationDbContext.Users.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return user;
        }
        #endregion

        #region Update Ticket
        public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            _applicationDbContext.Users.Update(user);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Ticket
        public async Task<bool> DeleteUserAsync(ApplicationUser user)
        {
            _applicationDbContext.Remove(user);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

    }
}
