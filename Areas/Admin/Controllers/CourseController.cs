using Academy.Models;
using Academy.Service;
using AutoMapper;
using Data_Access;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Areas.Admin.Controllers
{
    [Authorize]
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
        public ActionResult Index(string query =null ,int ? categoryId = null,int ? trainnerID = null)
        {
            var coursesListData = new CourseListModel();
            InitSelectList(ref coursesListData);    

            var courses = courseService.ReadAll(query,trainnerID, categoryId);
            var coursesList = Mapper.Map<List<CourseModel>>(courses);
            coursesListData.Courses = coursesList;
            return View(coursesListData);
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
                    courseData.ImageID = SaveImageFile(courseData.ImageFile);
                    
                   

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
        public ActionResult Edit(int ? id)
        {
            if (id == null || id == 0) return RedirectToAction("Index", "Dashboard");
            var ExitCourses = courseService.ReadById(id.Value);
            if (ExitCourses == null) return HttpNotFound($"This Courses ({id}) Not Fonud");
            var courseModel = Mapper.Map<CourseModel>(ExitCourses);
            InitSelectList(ref courseModel);
            return View(courseModel);
        }

        // POST: Admin/Course/Edit/5
        [HttpPost]
        public ActionResult Edit(CourseModel courseData)
        {
            InitSelectList(ref courseData);

            try
            {
               if(ModelState.IsValid)
               {
                    courseData.ImageID = SaveImageFile(courseData.ImageFile,courseData.ImageID);


                    var courseDTO = Mapper.Map<Course>(courseData);
                    courseDTO.Category = null;
                    courseDTO.Trainer = null;
                    var res = courseService.Update(courseDTO);
                    if (res >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                   
                        ViewBag.Message = $"An Error Occurred !!";
                }


                return View(courseData);
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(courseData);
            }
        }

        // GET: Admin/Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {

                var DeleteCourses = courseService.ReadById(id.Value);
                var courseModel = Mapper.Map<CourseModel>(DeleteCourses);
                InitSelectList(ref courseModel);

                return View(courseModel);
            }

            return RedirectToAction("Index");

        }

        // POST: Admin/Course/Delete/5
 
        public ActionResult DeleteConfirmed(int ? id)
        {
            

                if (id != null)
                {
                    var deleted = courseService.Delete(id.Value);
                    if (deleted)
                        return RedirectToAction("Index");

                    return RedirectToAction("Delete", new { ID = id });
                }

            return HttpNotFound();


        }
        private void InitSelectList(  ref CourseModel coursemodel)
        {

            var MappenCategoiesList = GetCategories();
            coursemodel.Categories = new SelectList(MappenCategoiesList, "ID", "Name");

            var MappenTrainerList = GetTrainers();
            coursemodel.Trainers = new SelectList(MappenTrainerList, "ID", "Name");

        }
        //filter
        private void InitSelectList(ref CourseListModel courseLsit)
        {
            var MappenCategoiesList = GetCategories();
            courseLsit.Categories = new SelectList(MappenCategoiesList, "ID", "Name");

            var MappenTrainerList =GetTrainers();
            courseLsit.Trainers = new SelectList(MappenTrainerList, "ID", "Name");


        }
        private IEnumerable<CategoryModel> GetCategories()
        {
            var category = categoryService.ReadAll();
           return Mapper.Map<IEnumerable<CategoryModel>>(category);
        }
        private IEnumerable<TrainerModel> GetTrainers()
        {
            var trainer = trainerService.ReadAll();
            return Mapper.Map<IEnumerable<TrainerModel>>(trainer);
        }

        private string SaveImageFile(HttpPostedFileBase imagefile ,string currentImageId ="")
        {
            
            if (imagefile != null)
            {
                var fileException = Path.GetExtension(imagefile.FileName);
                var imageGuid = Guid.NewGuid().ToString();

                string imageID= imageGuid + fileException;

                //save file 
                string filepath = Server.MapPath($"~/Uploads/Courses/{imageID}");
                imagefile.SaveAs(filepath);
                return imageID;
            }
            if (!string.IsNullOrEmpty(currentImageId))
            {
                string oldfilepath = Server.MapPath($"~/Uploads/Courses/{currentImageId}");
                System.IO.File.Delete(oldfilepath);
            }
            return currentImageId;
        }
    }
}
