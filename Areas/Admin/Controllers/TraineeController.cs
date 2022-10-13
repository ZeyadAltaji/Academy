using Academy.Models;
using Academy.Service;
using AutoMapper;
using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Areas.Admin.Controllers
{
    public class TraineeController : Controller
    {
        private readonly TraineeCourseService traineeCourseService;
        private readonly IMapper Mapper;
        public TraineeController()
        {
            traineeCourseService = new TraineeCourseService();
            Mapper = AutoMapperConfig.Mapper;
        }
        // GET: Admin/Trainee
        public ActionResult Index(int ? CourseId)
        {
            if (CourseId == null) return RedirectToAction("Index", "Dashboard" ,new {Areas ="Admin"});
            var trainees = traineeCourseService.GetTrainees(CourseId.Value);
          var CourseTrainees  =  Mapper.Map<IEnumerable<Trainee_Course>,IEnumerable<TraineeCourseModel>>(trainees);
            return View(CourseTrainees);
        }

        // GET: Admin/Trainee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Trainee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Trainee/Create
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

        // GET: Admin/Trainee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Trainee/Edit/5
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

        // GET: Admin/Trainee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Trainee/Delete/5
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
