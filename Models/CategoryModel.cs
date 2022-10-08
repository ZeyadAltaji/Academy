using Data_Access;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Models
{
    public class CategoryModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Category Name Is Required")]
        [StringLength(200 ,MinimumLength=10 ,ErrorMessage ="Category name be should be between 10 and 200")]
        public string Name { get; set; }
        public int? ParentID { get; set; }
        public string ParentName { get; set; }
        public SelectList MainCatogery { get; set; }

    }
}