using AutoMapper;
using Conference.Domain;
using Conference.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siit_Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siit_Conference.Controllers
{
    public class WorkshopController : Controller
    {
        private readonly IWorkshopService service;
        private readonly IMapper mapper;

        public WorkshopController(IWorkshopService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult List()
        {
            var allWorkshops = service.GetAllWorkshops();
            var model = mapper.Map<IEnumerable<WorkshopDto>>(allWorkshops);
                return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            WorkshopDto model = new WorkshopDto();
            if (id.HasValue)
            {
                var existingWorkshop = service.GetWorkshopById(id.Value);
                if (existingWorkshop != null)
                {
                    model = mapper.Map<WorkshopDto>(existingWorkshop);
                }
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit (WorkshopDto incomingModel)
        {
            if (incomingModel.Id > 0)
            {
                if (ModelState.IsValid)
                {
                    var workshopInDb = new Workshop();
                    workshopInDb = mapper.Map<Workshop>(incomingModel);
                    service.Update(workshopInDb);
                    service.Save();
                    return RedirectToAction("List", "Workshop");
                }
               
            }
            return View(incomingModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new WorkshopDto();
            return View(model);
        }

            
       [HttpPost]
       public IActionResult Create(WorkshopDto model)
        {
            if (ModelState.IsValid)
            {
                var newWorkshop = new Workshop();
                newWorkshop = mapper.Map<Workshop>(model);
                service.Add(newWorkshop);
                service.Save();
                return RedirectToAction("List", "Workshop");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var existingWorkshop = service.GetWorkshopById(id);
            if (existingWorkshop != null)
            {
                service.Delete(existingWorkshop);
                service.Save();
            }

            return RedirectToAction("List", "Workshop");
        }

       

        

       
        

       
    }
}
