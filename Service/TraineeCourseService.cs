using Academy.Interfaces;
using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Service
{
    public class TraineeCourseService : ITraineeCourseService
    {
        private readonly AcademyEntities academyEntities;
        public TraineeCourseService()
        {
            academyEntities = new AcademyEntities();    
        }

        public IEnumerable<Trainee_Course> GetTrainees(int ? CourseID =null)
        {
            return academyEntities.Trainee_Course.Where(X => CourseID==null|| X.Course_ID == CourseID);
        }
    }
}