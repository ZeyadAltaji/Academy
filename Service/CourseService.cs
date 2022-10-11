using Academy.Interfaces;
using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Service
{
    public class CourseService : ICourseService
    {
        private readonly AcademyEntities db;
        public CourseService()
        {
            db = new AcademyEntities();
        }
        public int Create(Course course)
        {
            course.Creation_date = DateTime.Now;

            db.Courses.Add(course);
            return db.SaveChanges();
        }
    }
}