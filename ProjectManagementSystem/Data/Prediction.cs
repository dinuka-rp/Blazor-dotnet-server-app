using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Data
{
    public class Prediction
    {
        public int ProjectsPerCompany { get; set; }
        public int PeoplePerProject { get; set; }

        public Prediction GeneratePrediction(DateTime date)
        {
            // TODO: call DB & return calculate relevant predictions
            Prediction prediction = new Prediction();
            return prediction;
        }
    }
}
