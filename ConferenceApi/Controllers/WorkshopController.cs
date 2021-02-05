using Conference.Domain;
using Conference.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Conf.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopController : ControllerBase
    {
        private readonly IWorkshopService workshopService;

        public WorkshopController(IWorkshopService workshopService)
        {
            this.workshopService = workshopService;
        }
        // GET: api/<WorkshopController>
        [HttpGet]
        public IEnumerable<Workshop> GetAll()
        {
            return workshopService.GetAllWorkshops();
        }

        // GET api/<WorkshopController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok  (workshopService.GetWorkshopById(id));
        }

        // POST api/<WorkshopController>
        [HttpPost]
        public IActionResult Create([FromBody] Workshop newWorkshop)
        {
            workshopService.Add(newWorkshop);
            workshopService.Save();
            return RedirectToAction("GetAll", "Workshop");
        }

        // PUT api/<WorkshopController>/5
        [HttpPut("{id}")]
        public IActionResult EditWorkshop(int id, [FromBody] Workshop incomingModel)
        {
            if (incomingModel.Id == id)
            {
                workshopService.Update(incomingModel);
                workshopService.Save();
            }
            

            
            return RedirectToAction("GetAll", "Workshop");
        }

        // DELETE api/<WorkshopController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var model = workshopService.GetWorkshopById(id);
            workshopService.Delete(model);
            workshopService.Save();
            return RedirectToAction("GetAll", "Workshop");
        }
    }
}
