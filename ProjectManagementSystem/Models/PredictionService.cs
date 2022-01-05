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

            Int32 daysDiff = (Int32)Math.Round((predictionDate - DateTime.Now).TotalDays, 0);
            Int32 monthDiff = (Int32)Math.Round((predictionDate - DateTime.Now).TotalDays, 0) / 30;
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

            // ------- Projects per company prediction

            Int32 expectedIncreaseInProjectsPerMonth = (projectsInCurrentMonth.Count - projectsInPastNMonth.Count) / monthDiff;
            Int32 expectedIncreaseInCompaniesPerMonth = (companiesInCurrentMonth.Count - companiesInNMonth.Count) / monthDiff;

            // prediction calculation
            Int32? projectsPerCompanyPrediction;

            Int32 predictedTotalCompanies = projectsInCurrentMonth.Count + (expectedIncreaseInProjectsPerMonth * monthDiff);
            Int32 predictedTotalProjects = companiesInCurrentMonth.Count + (expectedIncreaseInCompaniesPerMonth * monthDiff);

            if (predictedTotalCompanies == 0)
            {
                // avoid divide by zero error
                projectsPerCompanyPrediction = null;
            }
            else
            {
                projectsPerCompanyPrediction = predictedTotalCompanies / predictedTotalCompanies;
            }



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

            // ------- Users per project prediction

            Int32 expectedIncreaseInUsersPerProject = (usersInCurrentMonth.Count - usersInPastNMonth.Count) / monthDiff;

            // prediction calculation
            Int32? peoplePerProjectPrediction;

            Int32 predictedTotalUsers = usersInCurrentMonth.Count * expectedIncreaseInUsersPerProject;

            if (predictedTotalProjects == 0)
            {
                // avoid divide by zero error
                peoplePerProjectPrediction = null;
            }
            else
            {
                peoplePerProjectPrediction = predictedTotalUsers / predictedTotalProjects;
            }

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