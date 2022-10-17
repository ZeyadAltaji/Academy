using Academy.Interfaces;
using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Service
{
    public class CourseUnitService : ICourseUnitService
    {
        private readonly AcademyEntities _db;
        public CourseUnitService()
        {
            _db = new AcademyEntities();
        }
        public int Create(Course_Uits unit)
        {
            _db.Course_Uits.Add(unit);
            return _db.SaveChanges();
        }

        public Course_Uits Get(int Id)
        {
            return _db.Course_Uits.Find(Id);
        }

        public Course_Uits Get(int courseId, string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course_Uits> ReadCourseUnits(int courseId)
        {
            return _db.Course_Uits.Where(s => s.Course_ID == courseId);
        }

        public int Update(Course_Uits updatedCourse)
        {
            _db.Course_Uits.Attach(updatedCourse);
            _db.Entry(updatedCourse).State = System.Data.Entity.EntityState.Modified;
            return _db.SaveChanges();
        }
    }
}