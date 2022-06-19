using CourseApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseApp.Services
{
    public interface ITrainerServices
    {
        int Create(Trainer trainer);
        IEnumerable<Trainer> ReadAll();
        Trainer GetByEmail( string email);

    }
    public class TrainerServices : ITrainerServices
    {
        private readonly CousesAppContext context;
        public TrainerServices()
        {
            context = new CousesAppContext();
        }
        public int Create(Trainer trainer)
        {
            var trainerExist = GetByEmail(trainer.Email);
            if(trainerExist != null)
            {
                return -2;
            }
            else
            {
                trainer.CreatedAt = DateTime.Now;
                context.Trainers.Add(trainer);
                return context.SaveChanges();
            }
            
        }

        public Trainer GetByEmail(string email)
        {
            return context.Trainers.Where(e => e.Email == email).FirstOrDefault();
        }

        public IEnumerable<Trainer> ReadAll()
        {
            return context.Trainers.ToList();
        }
    }
}