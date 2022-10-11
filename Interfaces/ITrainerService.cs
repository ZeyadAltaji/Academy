using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Interfaces
{
    public interface ITrainerService
    {

        Trainer ReadById(int id);
        Trainer FindByEmail(string email);
        List<Trainer> ReadAll();
        int Create(Trainer newTrainer);
        int Update(Trainer UpdateTrainer);
        bool Delete(int id);
    }
}
