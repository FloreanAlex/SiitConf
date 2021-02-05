using AutoMapper;
using Conference.Domain;
using Conference.Services;
using Microsoft.AspNetCore.Mvc;
using Siit_Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siit_Conference.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpeakersController : Controller
    {
        private readonly ISpeakerService service;
        private readonly IMapper mapper;

        public SpeakersController(ISpeakerService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
       [HttpGet]
        public IActionResult List()
        {

            var allSpeaker=service.GetAllSpeakers();
            var speakerDto = mapper.Map<IEnumerable<SpeakerDto>>(allSpeaker);
            return View(speakerDto);
        }

        [HttpGet]
        public IActionResult Edit (int? id)
        {
            SpeakerDto model = new SpeakerDto();
            if (id.HasValue)
            {
                var existingSpeaker = service.GetSpeakerById(id.Value);
                if (existingSpeaker != null)
                {
                    model = mapper.Map<SpeakerDto>(existingSpeaker);
                }
            }
            return View(model);

        }

        [HttpPost]
        public IActionResult Edit (SpeakerDto incomingModel)
        {
            if (incomingModel.Id > 0)
            {
                if (ModelState.IsValid)
                {
                    var speakerInDb = new Speaker();
                    speakerInDb = mapper.Map<Speaker>(incomingModel);
                    service.Update(speakerInDb);
                    service.Save();
                    return RedirectToAction("List", "Speakers");
                }
            }
            return View(incomingModel);
        }
        [HttpGet]
        public IActionResult Create()
        {

            var model = new SpeakerDto();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SpeakerDto model)
        {
            if (ModelState.IsValid)
            {
                Speaker newSpeaker = new Speaker();
                newSpeaker = mapper.Map<Speaker>(model);
                service.Add(newSpeaker);
                service.Save();
                return RedirectToAction("List", "Speakers");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var existingSpeaker = service.GetSpeakerById(id);
            if (existingSpeaker != null)
            {

                service.Delete(existingSpeaker);
                service.Save();
            }

            return RedirectToAction("List", "Speakers");
        }

    }
}
