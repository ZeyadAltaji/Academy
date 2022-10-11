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
            var Trainer = ReadById(id);
            if (Trainer != null)
            {
                academyEntities.Trainers.Remove(Trainer);
                return academyEntities.SaveChanges() > 0 ? true : false;
            }
            return false;
        }

        public Trainer FindByEmail(string email)
        {
            return academyEntities.Trainers.Where(E=>E.Email == email).FirstOrDefault();    
        }

        public List<Trainer> ReadAll()
        {
            return academyEntities.Trainers.ToList();   
        }

        public Trainer ReadById(int id)
        {
            return academyEntities.Trainers.Find(id);
        }

        public int Update(Trainer UpdateTrainer)
        {
            academyEntities.Trainers.Attach(UpdateTrainer);
            academyEntities.Entry(UpdateTrainer).State = System.Data.Entity.EntityState.Modified;
            return academyEntities.SaveChanges();
        }
    }
}