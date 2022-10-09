using Academy.Interfaces;
using Academy.Models;
using Academy.Service;
using AutoMapper;
using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Academy.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        private readonly IMapper Mapper;
        private readonly CourseService courseService;
        public CourseController()
        {
            Mapper = AutoMapperConfig.Mapper;
            courseService = new CourseService();
        }
        // GET: Admin/Course
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(courseModel courseInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var courseDTO =Mapper.Map<Course>(courseInfo);
                    
                    int res = courseService.Create(courseDTO);
                    if (res >= 1) return RedirectToAction("Index");
                    ViewBag.Message = "An Errors Occurred !! ";
                }
                return View(courseInfo);
            }catch(Exception ex)
            {
                
                ViewBag.Message = ex.Message;
                return View(courseInfo);
            }
           
        }
    }
}