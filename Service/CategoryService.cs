using Academy.Interfaces;
using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly AcademyEntities academyEntities;
        public CategoryService()
        {
            academyEntities =new AcademyEntities(); 
        }
        public List<Category> ReadAll()
        {
            return academyEntities.Categories.ToList();
        }
    }
}