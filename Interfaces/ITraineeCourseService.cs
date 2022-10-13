using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Interfaces
{
    public interface ITraineeCourseService
    {
        IEnumerable<Trainee_Course> GetTrainees(int? CourseID =null);
    }
}
