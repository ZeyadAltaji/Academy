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

        public int Create(Category newcategory)
        {
            var categoryName = newcategory.Name.ToLower();
            var categoryNameResult = academyEntities.Categories.Where(x => x.Name.ToLower() == categoryName).Any();
            if (categoryNameResult)
            {
                return -2;
            }

            academyEntities.Categories.Add(newcategory);
            return academyEntities.SaveChanges();
        }

        public List<Category> ReadAll()
        {
            return academyEntities.Categories.ToList();
        }

        public Category ReadById(int id)
        {
            return academyEntities.Categories.Find(id);
        }

        public int Update(Category UpdateCategory)
        {
            var categoryName = UpdateCategory.Name.ToLower();
            var categoryNameResult = academyEntities.Categories.Where(x => x.Name.ToLower() == categoryName).Any();
            if (categoryNameResult)
            {
                return -2;
            }
            academyEntities.Categories.Attach(UpdateCategory);
            academyEntities.Entry(UpdateCategory).State = System.Data.Entity.EntityState.Modified;
            return academyEntities.SaveChanges();
        }
    }
}