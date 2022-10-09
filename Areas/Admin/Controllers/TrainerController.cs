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
    public class TrainerController : Controller
    {
        private readonly IMapper Mapper;
        private readonly TrainerService trainerService;
        public TrainerController()
        {
            trainerService = new TrainerService();
            Mapper = AutoMapperConfig.Mapper;
        }
        // GET: Admin/Trainer
        public ActionResult Index()
        {
            var trainerlist = trainerService.ReadAll();
            var maptrainerList = Mapper.Map<IEnumerable<TrainerModel>>(trainerlist);

            return View(maptrainerList);
        }

        // GET: Admin/Trainer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Trainer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Trainer/Create
        [HttpPost]
        public ActionResult Create(TrainerModel TrainerModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var MapTrainerDTO = Mapper.Map<Trainer>(TrainerModel);
                    int res = trainerService.Create(MapTrainerDTO);
                    if (res >= 1) return RedirectToAction("Index");
                    else if (res == -2) ViewBag.Message = "An already Exits Trainer With this Email !";
                    else ViewBag.Message = "An Errors Occcurred !!";
                    
                }
                return View(TrainerModel);
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(TrainerModel);
            }
        }

        // GET: Admin/Trainer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Trainer/Edit/5
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

        // GET: Admin/Trainer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Trainer/Delete/5
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
