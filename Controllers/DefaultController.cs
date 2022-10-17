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
    public class DefaultController : Controller
    {
        private readonly IMapper Mapper;
        private readonly CourseService courseService;
        public DefaultController()
        {
            courseService=new CourseService();
            Mapper = AutoMapperConfig.Mapper;
        }
        // GET: Default

        public ActionResult Index()
        {
            var courses = courseService.ReadAll();
            return View(Mapper.Map<List<Course>,List<CourseModel>>(courses));
        }
    }
}