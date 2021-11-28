using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Data
{
    public class Prediction
    {
        public Int32 ProjectsPerCompany { get; set; }
        public Int32 PeoplePerProject { get; set; }

        // TODO: move this into PredictionController
        public Prediction GeneratePrediction(DateTime date)
        {
            // TODO: call Service -> DB & return calculate relevant predictions
            Prediction prediction = new Prediction();
            return prediction;
        }
    }
}
