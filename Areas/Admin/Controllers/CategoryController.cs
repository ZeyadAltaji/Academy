using Academy.Models;
using Academy.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService categoryService;
        public CategoryController()
        {
            categoryService = new CategoryService();
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            var categories = categoryService.ReadAll();
            var categoriesList = new List<CategoryModel>();
            foreach (var item in categories)
                categoriesList.Add(new CategoryModel
                {
                    ID = item.ID,
                    Name = item.Name,
                    ParentId = item.Parent_ID,
                    ParentName = item.Category2?.Name
                });
            return View(categoriesList);
      
        }
    }
}