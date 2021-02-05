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

namespace Siit_Conference.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class TalkController : Controller
    {
        private readonly ITalkService service;
        private readonly IMapper mapper;

        public TalkController(ITalkService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        // GET: TalkController
        [HttpGet]
        public IActionResult List()
        {
            var allTalks = service.GetAllTalks();
            var model = mapper.Map<IEnumerable<TalkDto>>(allTalks);
            return View(model);
        }

        [HttpGet]
        // GET: TalkController/Details/5
        public IActionResult Edit(int? id)
        {
            var model = new TalkDto();
            if (id.HasValue)
            {
                var existingTalk = service.GetTalkById(id.Value);
                if (existingTalk != null)
                {
                    model = mapper.Map<TalkDto>(existingTalk);
                }

            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit (TalkDto incomingTalk)
        {
            if (incomingTalk.Id>0)
            {
                if (ModelState.IsValid)
                {
                    var model = new Talk();
                    model = mapper.Map<Talk>(incomingTalk);
                    service.Update(model);
                    service.Save();
                    return RedirectToAction("List", "Talk");
                }
            }

            return View(incomingTalk);
        }
        [HttpGet]
        // GET: TalkController/Create
        public IActionResult Create()
        {
            var model = new TalkDto();
            return View(model);
        }

        // POST: TalkController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(TalkDto model)
        {
            if (ModelState.IsValid)
            {
                var newTalk = new Talk();
                newTalk = mapper.Map<Talk>(model);
                service.Update(newTalk);
                service.Save();
                return RedirectToAction("List", "Talk");
            }
            
                return View(model);
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var existingTalk = service.GetTalkById(id);
            if (existingTalk != null)
            {

                service.Delete(existingTalk);
                service.Save();
            }
            return RedirectToAction("List", "Talk");

        }
    }
}
