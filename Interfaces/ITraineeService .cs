﻿using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Interfaces
{
    public interface ITraineeService
    {
        Trainee Create(Trainee trainee);
    }
}
