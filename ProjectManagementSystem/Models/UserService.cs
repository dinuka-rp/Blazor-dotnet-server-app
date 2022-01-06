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

        #region Get List of Users with User Roles
        public async Task<List<ApplicationUser>> GetAllUsersWithRolesAsync()
        {
            return await _applicationDbContext.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ToListAsync();
        }
        #endregion

        #region Get Users by Firstname/ Lastname/ Email/ Username Search
        public async Task<List<ApplicationUser>> SearchUsersAsync(String searchTerm)
        {
            String trimmedSearchTerm = searchTerm.Trim().ToLower();

            return await _applicationDbContext.Users.Where(c =>
            c.FirstName.ToLower().Contains(trimmedSearchTerm) ||
            c.LastName.ToLower().Contains(trimmedSearchTerm) ||
            c.Email.ToLower().Contains(trimmedSearchTerm) ||
            c.UserName.ToLower().Contains(trimmedSearchTerm)
            )
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ToListAsync();
        }
        #endregion

        #region Get Users by Firstname/ Lastname/ Email/ Username Search
        public async Task<List<ApplicationUser>> SearchUsersByProjectAsync(String searchTerm, Guid? projectId)
        {
            String trimmedSearchTerm = searchTerm.Trim().ToLower();

            if (projectId != null)
            {
                Project project = await _applicationDbContext.Projects.FirstOrDefaultAsync(c => c.Id.Equals(projectId));

                return await _applicationDbContext.Users.Where(c =>
                c.Projects.Contains(project) &&
                c.FirstName.ToLower().Contains(trimmedSearchTerm) ||
                c.LastName.ToLower().Contains(trimmedSearchTerm) ||
                c.Email.ToLower().Contains(trimmedSearchTerm) ||
                c.UserName.ToLower().Contains(trimmedSearchTerm)
                )
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .ToListAsync();
            }
            else {
                return await _applicationDbContext.Users.Where(c =>
                c.FirstName.ToLower().Contains(trimmedSearchTerm) ||
                c.LastName.ToLower().Contains(trimmedSearchTerm) ||
                c.Email.ToLower().Contains(trimmedSearchTerm) ||
                c.UserName.ToLower().Contains(trimmedSearchTerm)
                )
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .ToListAsync();
            }
        }
        #endregion

        #region Insert User
        public async Task<bool> InsertUserAsync(ApplicationUser user)
        {
            await _applicationDbContext.Users.AddAsync(user);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get User by Id
        public async Task<ApplicationUser> GetUserAsync(String Id)
        {
            ApplicationUser user = await _applicationDbContext.Users
                .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .Include(u => u.Projects)
                .FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return user;
        }
        #endregion

        #region Update User
        public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            _applicationDbContext.Users.Update(user);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete User
        public async Task<bool> DeleteUserAsync(ApplicationUser user)
        {
            _applicationDbContext.Remove(user);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

    }
}

//reference: https://stackoverflow.com/a/51005445/11005638