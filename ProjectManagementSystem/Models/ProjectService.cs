using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementSystem.Data;

namespace ProjectManagementSystem.Models
{
    public class ProjectService
    {
        #region Property
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion

        #region Constructor
        public ProjectService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #endregion

        #region Get List of Projects
        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _applicationDbContext.Projects.ToListAsync();
        }
        #endregion

        #region Get Projects by Project Search name
        public async Task<List<Project>> SearchProjectsAsync(String searchTerm)
        {
            String trimmedSearchTerm = searchTerm.Trim().ToLower();

            return await _applicationDbContext.Projects.Where(c =>
                c.Name.ToLower().Contains(trimmedSearchTerm)
            ).ToListAsync();
        }
        #endregion

        #region Insert Project
        public async Task<bool> InsertProjectAsync(Project project)
        {
            await _applicationDbContext.Projects.AddAsync(project);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Project by Id
        public async Task<Project> GetProjectAsync(Guid Id)
        {
            Project project = await _applicationDbContext.Projects
                .Include(r => r.Company)
                .Include(r => r.Tickets).ThenInclude(rt=>rt.Users)
                .Include(r => r.Users)
                .ThenInclude(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return project;
        }
        #endregion

        #region Update Project
        public async Task<bool> UpdateProjectAsync(Project project)
        {
            _applicationDbContext.Projects.Update(project);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Project
        public async Task<bool> DeleteProjectAsync(Project project)
        {
            _applicationDbContext.Remove(project);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
