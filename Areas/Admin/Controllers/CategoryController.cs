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
        CategoryModel categoryModel;
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
                    ParentName =item.Category2?.Name
                   
                });
            return View(categoriesList);
      
        }
        public ActionResult Create()
        {
            var CateModel = new CategoryModel();
            InitMainCategory(null,ref CateModel);
            return View(CateModel);
        }
        [HttpPost]
        public ActionResult Create(CategoryModel categoryModel)
        {
          
                int createdResult = categoryService.Create(new Data_Access.Category
                {
                    Name = categoryModel.Name,
                    Parent_ID=categoryModel.ParentID
                });
                if (createdResult == -2)
                {
                InitMainCategory(null,ref categoryModel);

                ViewBag.Message = "Category Name is exists !! ";
                    return View(categoryModel);
                }

                return RedirectToAction("Index");
       
        }

        public ActionResult Updated(int ? id)
        {
            if(id == null || id == 0)
            {
                return RedirectToAction("Index" , "Dashboard");
            }
            var ExitCatogory = categoryService.ReadById(id.Value);
            if(ExitCatogory == null)
            {
                return HttpNotFound($"This Category ({id}) not Fonud");
            }
            var categoryModel = new CategoryModel
            {
                ID =ExitCatogory.ID,
                Name=ExitCatogory.Name,
                ParentID = ExitCatogory.Parent_ID
            };
            InitMainCategory(ExitCatogory.ID, ref categoryModel);

            return View(categoryModel);
        }
        [HttpPost]
        public ActionResult Updated(CategoryModel categoryModel)
        {
          
                var UpdateCategory = new Category
                {
                    ID = categoryModel.ID,
                    Name = categoryModel.Name,
                    Parent_ID = categoryModel.ParentID

                };
              var res = categoryService.Update(UpdateCategory);
                if (res == -2)
                {
                InitMainCategory(categoryModel.ID, ref categoryModel);

                ViewBag.Message = "Category Name is exists !! ";
                    return View(categoryModel);
                }
                else if (res > 0)
                {
                    ViewBag.Success = true;
                    ViewBag.Message = $"Category ({categoryModel.ID}) Updated SuccessFully . ";
                }
                else
                    ViewBag.Message = $"An Error Occurred !!";

            InitMainCategory(categoryModel.ID, ref categoryModel);

            return View(categoryModel);
        }
        private void InitMainCategory(int? CategoryToexclude, ref CategoryModel categoryModel)
        {
            var CategoryList = categoryService.ReadAll();
             categoryModel.MainCatogery = new SelectList(CategoryList, "ID", "Name");
            if (CategoryToexclude != null)
            {
                var currentCate = CategoryList.Where(X=>X.ID == CategoryToexclude).FirstOrDefault();
                CategoryList.Remove(currentCate);
            }
           
        }
    }
}