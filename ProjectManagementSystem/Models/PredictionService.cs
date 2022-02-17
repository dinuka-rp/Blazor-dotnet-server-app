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

            //Int32 daysDiff = (Int32)Math.Round((predictionDate - DateTime.Now).TotalDays, 0);
            //Int32 monthDiff = (Int32)Math.Round((predictionDate - DateTime.Now).TotalDays, 0) / 30;
            Int32 NumOfDaysDiff = (predictionDate - DateTime.Today).Days;
            DateTime pastDate = DateTime.Today.AddDays(-NumOfDaysDiff);
            
            // use LINQ - to get required details here
            // TODO: check if the logic to get the projects is correct here
            List<Project> projectsInCurrentMonth = await _applicationDbContext.Projects
                .Where(project => DateTime.Now > project.StartedOn &&
                                project.CompletedOn == null ).ToListAsync();
            List<Project> projectsInPastNMonth = await _applicationDbContext.Projects
                .Where(project => pastDate > project.StartedOn &&
                                !(pastDate > project.CompletedOn)).ToListAsync();

            // ---------------
            HashSet<Company> companiesInCurrentMonth = new();     // hashset does not allow duplicates
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

            Int32 expectedChangeInProjectsPerMonth = projectsInCurrentMonth.Count - projectsInPastNMonth.Count;
            Int32 expectedChangeInCompaniesPerMonth = companiesInCurrentMonth.Count - companiesInNMonth.Count;

            // prediction calculation
            Int32? projectsPerCompanyPrediction;

            Int32 predictedTotalCompanies = projectsInCurrentMonth.Count + expectedChangeInProjectsPerMonth;
            Int32 predictedTotalProjects = companiesInCurrentMonth.Count + expectedChangeInCompaniesPerMonth;

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
                if (project.Users != null)
                {
                    foreach (var user in project.Users)
                    {
                        usersInCurrentMonth.Add(user);
                    }
                }
                else
                {
                    ApplicationUser dummyUser = new();
                    usersInCurrentMonth.Add(dummyUser);
                }
            }

            HashSet<ApplicationUser> usersInPastNMonth = new();
            foreach (var project in projectsInCurrentMonth)
            {
                if (project.Users != null)
                {
                    foreach (var user in project.Users)
                    {
                        usersInPastNMonth.Add(user);
                    }
                }
                else
                {
                    ApplicationUser dummyUser = new();
                    usersInPastNMonth.Add(dummyUser);
                }
            }

            // ------- Users per project prediction

            Int32 expectedChangeInUsersPerProject = usersInCurrentMonth.Count - usersInPastNMonth.Count;

            // prediction calculation
            Int32? peoplePerProjectPrediction;

            Int32 predictedTotalUsers = usersInCurrentMonth.Count;

            if (expectedChangeInUsersPerProject != usersInCurrentMonth.Count)
            {
                predictedTotalUsers = usersInCurrentMonth.Count + expectedChangeInUsersPerProject;
            }

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