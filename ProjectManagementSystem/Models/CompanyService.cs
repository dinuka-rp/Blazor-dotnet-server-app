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

        #region Get List of Companies
        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await _applicationDbContext.Companies.ToListAsync();
        }
        #endregion

        #region Insert Company
        public async Task<bool> InsertCompanyAsync(Company company)
        {
            await _applicationDbContext.Companies.AddAsync(company);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Company by Id
        public async Task<Company> GetCompanyAsync(Guid Id)
        {
            Company company = await _applicationDbContext.Companies.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return company;
        }
        #endregion

        #region Update Company
        public async Task<bool> UpdateCompanyAsync(Company company)
        {
            _applicationDbContext.Companies.Update(company);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Company
        public async Task<bool> DeleteCompanyAsync(Company company)
        {
            _applicationDbContext.Remove(company);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

    }
}
