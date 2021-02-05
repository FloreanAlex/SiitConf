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
    public class SpeakersController : ControllerBase
    {
        private readonly ISpeakerService speakerService;

        public SpeakersController(ISpeakerService speakerService)
        {
            this.speakerService = speakerService;
        }
        // GET: api/<SpeakersController>
        [HttpGet]
        public IEnumerable<Speaker> GetAllSpeakers()
        {
            return speakerService.GetAllSpeakers();
        }

        // GET api/<SpeakersController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok (speakerService.GetSpeakerById(id));
        }

        // POST api/<SpeakersController>
        [HttpPost]
        public IActionResult Create([FromBody] Speaker speaker)
        {
            speakerService.Add(speaker);
            speakerService.Save();
            return Ok (speaker);
        }

        // PUT api/<SpeakersController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Speaker speaker)
        {
            speakerService.Update(speaker);
            speakerService.Save();
            return Ok(speaker);
        }

        // DELETE api/<SpeakersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var model = speakerService.GetSpeakerById(id);
            speakerService.Delete(model);
            speakerService.Save();
            return RedirectToAction("GetAllSpeakers", "Speakers");
        }
    }
}
