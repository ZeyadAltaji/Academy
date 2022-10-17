using Academy.Interfaces;
using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Service
{
    public class TraineeService : ITraineeService
    {
        private readonly AcademyEntities academyEntities;
        public TraineeService()
        {
            academyEntities = new AcademyEntities();    
        }

        public Trainee Create(Trainee trainee)
        {
           academyEntities.Trainees.Add(trainee);
            int saveres= academyEntities.SaveChanges();
            if (saveres > 0)
            {
                return trainee;
            }
            return null;
        }
    }
}