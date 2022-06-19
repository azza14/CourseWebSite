using AutoMapper;
using CourseApp.App_Start;
using CourseApp.Areas.Admin.Models;
using CourseApp.Data;
using CourseApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseApp.Areas.Admin.Controllers
{
    public class TrainersController : Controller
    {
        private TrainerServices service;
        private readonly IMapper mapper;
        public TrainersController()
        {
            service = new TrainerServices();
            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Admin/Trainers
        public ActionResult Index()
        {
            var trainers = service.ReadAll();
            var trainerList = mapper.Map<List<TrainerModel>>(trainers);
            return View(trainerList);
        }
        // GET: Admin/Trainers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Trainers/Create
        [HttpPost]
        public ActionResult Create(TrainerModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var trainerMapped = mapper.Map<Trainer>(model);

                    var result = service.Create(trainerMapped);
                    if(result == -2)
                    {
                        ViewBag.Message = " An Aready  exists trainer with this email";
                    }
                    else if( result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "An Error occured";
                    }
                }
                return View(model);

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(model);
            }
        }

       
    }
}
