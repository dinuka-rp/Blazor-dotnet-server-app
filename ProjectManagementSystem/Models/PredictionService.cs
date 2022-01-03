using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagementSystem.Data;

namespace ProjectManagementSystem.Models
{
    public class PredictionService
    {
        #region Property
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion

        #region Constructor
        public PredictionService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #endregion

        #region Get Prediction
        public async Task<PredictionDTO> GeneratePrediction(DateTime predictionDate)
        {
            Int32 dateDiff = (Int32)(predictionDate - DateTime.Now).TotalDays;
            DateTime pastDate = predictionDate.Subtract(predictionDate - DateTime.Now);


            // use LINQ - to get required details here
            // TODO: check if the logic to get the projects is correct here
            List<Project> projectsInCurrentMonth = await _applicationDbContext.Projects.Where(project => project.CompletedOn == null &&
                                                DateTime.Now > project.StartedOn).ToListAsync();
            List<Project> projectsInPastNMonth = await _applicationDbContext.Projects.Where(project => pastDate < project.StartedOn &&
                                                (pastDate < project.CompletedOn || project.CompletedOn == null)).ToListAsync();

            // ---------------
            HashSet<Company> companiesInCurrentMonth = new();
            foreach (var project in projectsInCurrentMonth)
            {
                companiesInCurrentMonth.Add(project.Company);
            }

            HashSet<Company> companiesInNMonth = new();
            foreach (var project in projectsInPastNMonth)
            {
                companiesInNMonth.Add(project.Company);
            }

            // Projects per company prediction
            Int32 projectsPerCompanyCurrent = projectsInCurrentMonth.Count / companiesInCurrentMonth.Count;
            Int32 projectsPerCompanyNMonth = projectsInPastNMonth.Count / companiesInNMonth.Count;


            Int32 expectedIncreaseInProjectsPerCompany = (projectsPerCompanyCurrent - projectsPerCompanyNMonth) / dateDiff;

            // prediction calculation
            Int32 projectsPerCompanyPrediction = projectsPerCompanyCurrent * expectedIncreaseInProjectsPerCompany;

            // ---------------
            HashSet<ApplicationUser> usersInCurrentMonth = new();
            foreach (var project in projectsInCurrentMonth)
            {
                foreach (var user in project.Users)
                {
                    usersInCurrentMonth.Add(user);
                }
            }

            HashSet<ApplicationUser> usersInPastNMonth = new();
            foreach (var project in projectsInCurrentMonth)
            {
                foreach (var user in project.Users)
                {
                    usersInPastNMonth.Add(user);
                }
            }

            // Users per project prediction
            Int32 usersPerProjectCurrent = usersInCurrentMonth.Count / projectsInCurrentMonth.Count;
            Int32 usersPerProjectNMonth = usersInPastNMonth.Count / projectsInPastNMonth.Count;

            Int32 expectedIncreaseInUsersPerProject = (usersPerProjectCurrent - usersPerProjectNMonth) / dateDiff;

            // prediction calculation
            Int32 peoplePerProjectPrediction = usersPerProjectCurrent * expectedIncreaseInUsersPerProject;

            return new PredictionDTO
            {
                PeoplePerProject = peoplePerProjectPrediction,
                ProjectsPerCompany = projectsPerCompanyPrediction,
            };
        }
        #endregion
    }
}

// reference: https://stackoverflow.com/a/1607352/11005638