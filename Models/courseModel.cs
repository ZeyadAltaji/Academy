using Data_Access;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Models
{
    public class courseModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public System.DateTime Creation_date { get; set; }
        [Required]
        [Display(Name="Category")]
        public int Category_ID { get; set; }
        [Required]
        [Display(Name = "Trainer")]

        public Nullable<int> Trainer_ID { get; set; }
        public string description { get; set; }
        public string  CategoryName { get; set; }
        public string TrainerName { get; set; }
        public SelectList Trainer { get; set; }
        public  SelectList Category { get; set; }

    }
}