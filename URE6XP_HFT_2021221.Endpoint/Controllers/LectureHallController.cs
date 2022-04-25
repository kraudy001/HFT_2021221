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
    public class LectureHallController : ControllerBase
    {
        ILectureHallLogic ll;
        IHubContext<SignalRHub> hub;

        public LectureHallController(ILectureHallLogic lectureHallLogic, IHubContext<SignalRHub> hub)
        {
            this.ll = lectureHallLogic;
            this.hub = hub;
        }

        // GET: /LectureHall
        [HttpGet]
        public IEnumerable<LectureHall> Get()
        {
            return ll.ReadAll();
        }

        // GET /LectureHall/5
        [HttpGet("{id}")]
        public LectureHall Get(string id)
        {
            return ll.Read(id);
        }

        // POST /LectureHall
        [HttpPost]
        public IActionResult Post([FromBody] LectureHall value)
        {
            try
            {
                ll.Create(value);
                hub.Clients.All.SendAsync("LectureHallCreate", value);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
            
        }

        // PUT /LectureHall
        [HttpPut]
        public void Put([FromBody] LectureHall value)
        {
            ll.Update(value);
            hub.Clients.All.SendAsync("LectureHallUpdated", value);
        }

        // DELETE /LectureHall/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var toDelet = ll.Read(id);
            ll.Delete(id);
            hub.Clients.All.SendAsync("LectureHallDelete", toDelet);

        }
    }
}
