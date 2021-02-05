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
    public class TalksController : ControllerBase
    {
        private readonly ITalkService talkServices;

        public TalksController(ITalkService talkServices)
        {
            this.talkServices = talkServices;
        }
        // GET: api/<TalksController>
        [HttpGet]
        public IEnumerable<Talk> Get()
        {
            return talkServices.GetAllTalks();
        }

        // GET api/<TalksController>/5
        [HttpGet("{id}")]
        public IActionResult GetTalk(int id)
        {
            return Ok (talkServices.GetTalkById(id));
        }

        // POST api/<TalksController>
        [HttpPost]
        public IActionResult AddTalk([FromBody] Talk talk)
        {
            return Ok (talkServices.Add(talk));
        }

        // PUT api/<TalksController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateTalk(int id, [FromBody] Talk talk)
        {
            return Ok (talkServices.Update(talk));
        }

        // DELETE api/<TalksController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
           
            
        //}
    }
}
