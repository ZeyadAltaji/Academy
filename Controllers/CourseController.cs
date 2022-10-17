using Academy.Models;
using Academy.Service;
using AutoMapper;
using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Controllers
{
    public class CourseController : Controller
    {
        private readonly IMapper Mapper;
        private readonly CourseService courseService;
        public CourseController()
        {
            courseService = new CourseService();
            Mapper = AutoMapperConfig.Mapper;
        }
        // GET: Course
        public ActionResult Index()
        {
            var courses = courseService.ReadAll();
            var DisplayListCourse = Mapper.Map<List<Course>, List<CourseModel>>(courses);
            return View(DisplayListCourse);
        }
        public ActionResult Info(int? Id)
        {
            if (Id == null || Id == 0)
                return HttpNotFound("This course not found!");

            var courseInfo = courseService.ReadById(Id.Value);
            if (courseInfo == null)
                return HttpNotFound("This course not found!");

            var mappedCourseInfo = Mapper.Map<Course, CourseModel>(courseInfo);

            return View(mappedCourseInfo);
        }
        public ActionResult Subscribe(int Id)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { returnUrl = $"/Course/Subscribe/{Id}" });
            }

            return View();
        }

    }
}