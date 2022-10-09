using Academy.Models;
using Academy.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data_Access;
using AutoMapper;

namespace Academy.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
       
        private readonly CategoryService categoryService;
        private readonly IMapper Mapper;
        public CategoryController()
        {
            categoryService = new CategoryService();
            Mapper = AutoMapperConfig.Mapper;
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            var categories = categoryService.ReadAll();
            var categoriesList = Mapper.Map<List<CategoryModel>>(categories);
            //var categoriesList = new List<CategoryModel>();
            //foreach (var item in categories)
            //    categoriesList.Add(new CategoryModel
            //    {
            //        ID = item.ID,
            //        Name = item.Name,
            //        ParentName =item.Category2?.Name

            //    });
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
            var newcate = Mapper.Map<Category>(categoryModel);
            newcate.Category2 = null;
            int createdResult = categoryService.Create(newcate);
                //int createdResult = categoryService.Create(new Data_Access.Category
                //{
                //    Name = categoryModel.Name,
                //    Parent_ID=categoryModel.ParentID
                //});
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
        public ActionResult Delete(int ? id)
        {
            if(id != null)
            {
                var category = categoryService.ReadById(id.Value);
                var categoryInfo = new CategoryModel
                {
                    ID = category.ID,
                    Name = category.Name,
                    ParentName = category.Category2?.Name

                };
                return View(categoryInfo);
            }

            return RedirectToAction("Index");

        }
        public ActionResult DeleteConfirmed(int? id)
        {
            if(id != null)
            {
                var deleted = categoryService.Delete(id.Value);
                if (deleted)
                    return RedirectToAction("Index");

                return RedirectToAction("Delete", new { ID = id });
            }
         
            return HttpNotFound();  
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