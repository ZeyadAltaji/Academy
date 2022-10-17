using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Interfaces
{
    public interface ICourseUnitService
    {
        int Create(Course_Uits unit);

       // SavingStatus Create(Course_Uits unit);
        int Update(Course_Uits updatedCourse);
 
        IEnumerable<Course_Uits> ReadCourseUnits(int courseId);
        Course_Uits Get(int Id);
        Course_Uits Get(int courseId, string name);
    }
}