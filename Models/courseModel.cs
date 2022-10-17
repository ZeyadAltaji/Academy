using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Academy.Models
{
    public class CourseModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public System.DateTime Creation_date { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int Category_ID { get; set; }
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Trainer")]
        public Nullable<int> Trainer_ID { get; set; }
        public string TrainerName { get; set; }

        public string description { get; set; }

        public SelectList Trainers { get; set; }
        public SelectList Categories { get; set; }
        private string _ImageID;
        public string ImageID 
        {
            get 
            {
                return _ImageID;
            }
            set 
            {
                _ImageID = string.IsNullOrWhiteSpace(value)? "empty.jpg" : value;
            } 
        }
        
        public HttpPostedFileBase ImageFile{ get; set; }
    }
    public class CourseListModel
    {
        public IEnumerable<CourseModel> Courses { get; set; }
        public string Query { get; set; }

        [Display (Name="Trainer")]
         public int trainerID { get; set; }
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public SelectList Trainers { get; set; }
        public SelectList Categories { get; set; }
    }
}