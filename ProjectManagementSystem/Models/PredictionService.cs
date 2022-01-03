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
        //public async Task<PredictionDTO> GeneratePrediction(DateTime date)
        //{
        //    //use LINQ - to get required details here
        //    //Int32 projectsPerCompany = await _applicationDbContext.

        //    //return new PredictionDTO { 
        //    //    PeoplePerProject=,
        //    //    ProjectsPerCompany=,
        //    //};
        //}
        #endregion
    }
}
