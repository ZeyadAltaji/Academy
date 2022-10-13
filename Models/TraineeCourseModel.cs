using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Models
{
    public class TraineeCourseModel
    {
        public int CourseID { get; set; }
        public DateTime Registration_Date { get; set; }
        public TraineeModel Trainee { get; set; }
    }
}