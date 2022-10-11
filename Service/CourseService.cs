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

        public List<Course> ReadAll()
        {
            return db.Courses.ToList();
        }

        public Course ReadById(int id)
        {
            return db.Courses.Find(id);
        }

        public int Update(Course Updatedcourse)
        {


            db.Courses.Attach(Updatedcourse);
            db.Entry(Updatedcourse).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}