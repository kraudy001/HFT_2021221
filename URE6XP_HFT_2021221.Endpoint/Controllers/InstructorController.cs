using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Logic;
using URE6XP_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace URE6XP_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        IInstructorLogic il;
        IHubContext<SignalRHub> hub;
        public InstructorController(IInstructorLogic instructorLogic, IHubContext<SignalRHub> hub)
        {
            this.il = instructorLogic;
            this.hub = hub;
        }


        // GET: /Instructor
        [HttpGet]
        public IEnumerable<Instructor> Get()
        {
            return il.ReadAll();
        }

        // GET /Instructor/5
        [HttpGet("{id}")]
        public Instructor Get(string id)
        {
            return il.Read(id);
        }

        // POST /Instructor
        [HttpPost]
        public IActionResult Post([FromBody] Instructor value)
        {
            try
            {
                il.Create(value);
                hub.Clients.All.SendAsync("InstructorCreated", value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
            return Ok();
        }

        // PUT /Instructor
        [HttpPut]
        public IActionResult Put([FromBody] Instructor value)
        {
            try
            {
                il.Update(value);
                hub.Clients.All.SendAsync("InstructorUpdated", value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok();
        }

        // DELETE /Instructor/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var toDelet = il.Read(id);
            il.Delete(id);
            hub.Clients.All.SendAsync("InstructorDeleted", toDelet);
        }
    }
}
