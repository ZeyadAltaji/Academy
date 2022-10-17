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
    public class CourseUnitsController : Controller
    {
        private readonly IMapper Mapper;
        private readonly CourseUnitService courseUnitService;
        public CourseUnitsController()
        {
            Mapper = AutoMapperConfig.Mapper;
            courseUnitService = new CourseUnitService();
        }
        // GET: Admin/CourseUnits?courseId=1
        public ActionResult Index(int? courseId)
        {
            if(courseId == null)
            {
                return HttpNotFound();
            }
            var units = courseUnitService.ReadCourseUnits(courseId.Value);
            var mappedUnits = Mapper.Map<IEnumerable<Course_Uits>, IEnumerable<CourseUnitModel>>(units);

            ViewBag.CourseName = mappedUnits.FirstOrDefault()?.CourseName;
            ViewBag.CourseId = courseId;
            return View();
        }

        // GET: Admin/CourseUnits/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/CourseUnits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CourseUnits/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CourseUnits/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/CourseUnits/Edit/5
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

        // GET: Admin/CourseUnits/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CourseUnits/Delete/5
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
    }
}
