using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementSystem.Data;


namespace ProjectManagementSystem.Models
{
    public class CompanyService
    {
        #region Property
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion

        #region Constructor
        public CompanyService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #endregion

        #region Get List of Users
        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await _applicationDbContext.Companies.ToListAsync();
        }
        #endregion
    }
}
