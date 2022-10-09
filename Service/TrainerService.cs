using Academy.Interfaces;
using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Service
{
    public class TrainerService : ITrainerService
    {
        private readonly AcademyEntities academyEntities;
        public TrainerService()
        {
            academyEntities = new AcademyEntities();
        }

        public int Create(Trainer newTrainer)
        {
            var ExitTrainer = FindByEmail(newTrainer.Email);
            if (ExitTrainer != null) return -2;
            newTrainer.Creation_Date = DateTime.Now;
            academyEntities.Trainers.Add(newTrainer);
            return academyEntities.SaveChanges();
            
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Trainer FindByEmail(string email)
        {
            return academyEntities.Trainers.Where(E=>E.Email == email).FirstOrDefault();    
        }

        public List<Trainer> ReadAll()
        {
            return academyEntities.Trainers.ToList();   
        }

        public Category ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Trainer UpdateTrainer)
        {
            throw new NotImplementedException();
        }
    }
}