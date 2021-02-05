using AutoMapper;
using Conference.Data;
using Conference.Domain;
using Conference.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Siit_Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siit_Conference.Controllers
{
    public class TalkController : Controller
    {
        private readonly ITalkService service;
        private readonly ISpeakerRepository repo;
        private readonly IMapper mapper;

        public TalkController(ITalkService service,ISpeakerRepository repo, IMapper mapper)
        {
            this.service = service;
            this.repo = repo;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult List()
        {

            IEnumerable<Talk> allTalks = service.GetAllTalks();
            var talkDto = mapper.Map<IEnumerable<TalkDto>>(allTalks);

            return View(talkDto);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            TalkDto model = new TalkDto();
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
        public IActionResult Edit(TalkDto incomingModel)
        {

            if (incomingModel.Id > 0)
            {
                if (ModelState.IsValid)
                {
                    Talk model = new Talk();
                    model = mapper.Map<Talk>(incomingModel);
                    service.Update(model);
                    service.Save();

                    return RedirectToAction("List", "Talk");
                }
            }
            return View(incomingModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new TalkDto();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TalkDto model)
        {
            if (ModelState.IsValid)
            {

                Talk newTalk = new Talk();
                newTalk = mapper.Map<Talk>(model);
                service.Add(newTalk);
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
        [HttpGet]
        public IActionResult FillData()
        {
            var model = new TalkDto();
            return new JsonResult(model);
        }

        [HttpGet]
        public IActionResult GetSpeakerData(int id)
        {
            var speaker = repo.GetSpeaker(id);
            var model = new List<SelectModel>();
            for (int i = id; i < id + 10; i++)
            {
                var currentModel = new SelectModel();
                currentModel.Id = i;
                currentModel.TextToDisplay = speaker.FullName + 1;
                model.Add(currentModel);
            }
            return new JsonResult(model);
        }
        
    }
}
