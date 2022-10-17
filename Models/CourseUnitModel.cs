using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Models
{
    public class CourseUnitModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Course_ID { get; set; }

        public string CourseName { get; set; }
    }
}