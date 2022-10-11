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
        public ActionResult Edit(int ? id)
        {
            if (id == null || id == 0) return RedirectToAction("Index", "Dashboard");
            var ExitTrainer = trainerService.ReadById(id.Value);
            if (ExitTrainer == null) return HttpNotFound($"This Trainer ({id}) Not Fonud");
            var trainerModel = Mapper.Map<TrainerModel>(ExitTrainer);
            
            return View(trainerModel);
        }

        // POST: Admin/Trainer/Edit/5
        [HttpPost]
        public ActionResult Edit(TrainerModel trainerModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var trainerDTO = Mapper.Map<Trainer>(trainerModel);
                    var res = trainerService.Update(trainerDTO);
                    if (res >= 1)
                    {
                        return RedirectToAction("Index");
                    }

                    ViewBag.Message = $"An Error Occurred !!";
                }
                return View(trainerModel);

            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(trainerModel);
            }
        }

        // GET: Admin/Trainer/Delete/5
        public ActionResult Delete(int ? id)
        {
            if (id != null)
            {

                var Deletetrainer = trainerService.ReadById(id.Value);
                var trainerModel = Mapper.Map<TrainerModel>(Deletetrainer);
                return View(trainerModel);
            }

            return RedirectToAction("Index");
        }

        // POST: Admin/Trainer/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int ? id)
        {
            try
            {
                if (id != null)
                {
                    var deleted = trainerService.Delete(id.Value);
                    if (deleted)
                        return RedirectToAction("Index");

                    return RedirectToAction("Delete", new { ID = id });
                }

                return HttpNotFound();
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
