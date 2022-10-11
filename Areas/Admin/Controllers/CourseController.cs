using Academy.Models;
using Academy.Service;
using AutoMapper;
using Data_Access;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        private readonly IMapper Mapper;
        private readonly CourseService courseService;
        private readonly CategoryService categoryService;
        private readonly TrainerService trainerService;
        public CourseController()
        {
            Mapper = AutoMapperConfig.Mapper;
            courseService = new CourseService();
            categoryService = new CategoryService();
            trainerService = new TrainerService();
        }
        // GET: Admin/Course
        public ActionResult Index()
        {
            var courses = courseService.ReadAll();
            var coursesList = Mapper.Map<List<CourseModel>>(courses);
            return View(coursesList);
        }

        // GET: Admin/Course/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Course/Create
        public ActionResult Create()
        {
            var courseModel = new CourseModel();

            InitSelectList(ref courseModel);
            return View(courseModel);

        }

        // POST: Admin/Course/Create
        [HttpPost]
        public ActionResult Create(CourseModel courseData)
        {
            InitSelectList(ref courseData);

            try
            {
                if (ModelState.IsValid)
                {
                  

                    var courseDTO = Mapper.Map<Course>(courseData);
                    courseDTO.Category = null;
                    courseDTO.Trainer = null;

                    int result = courseService.Create(courseDTO);

                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }

                    ViewBag.Message = "An error occurred!";
                }
                return View(courseData);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(courseData);
            }
        }

        // GET: Admin/Course/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Course/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private void InitSelectList(ref CourseModel coursemodel)
        {

            var category = categoryService.ReadAll();
            var MappenCategoiesList = Mapper.Map<IEnumerable<CategoryModel>>(category);
            coursemodel.Categories = new SelectList(MappenCategoiesList, "ID", "Name");
            var trainer = trainerService.ReadAll();
            var MappenTrainerList = Mapper.Map<IEnumerable<TrainerModel>>(trainer);
            coursemodel.Trainers = new SelectList(MappenTrainerList, "ID", "Name");
        }
    }
}
