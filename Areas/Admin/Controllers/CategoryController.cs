using Academy.Models;
using Academy.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data_Access;

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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                int createdResult = categoryService.Create(new Data_Access.Category
                {
                    Name = categoryModel.Name
                });
                if (createdResult == -2)
                {
                    ViewBag.Message = "Category Name is exists !! ";
                    return View(categoryModel);
                }

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}