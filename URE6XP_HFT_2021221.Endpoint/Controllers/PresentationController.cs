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
    public class PresentationController : ControllerBase
    {
        IPresentationLogic pl;
        IHubContext<SignalRHub> hub;

        public PresentationController(IPresentationLogic presentationLogic, IHubContext<SignalRHub> hub)
        {
            this.pl = presentationLogic;
            this.hub = hub;
        }


        // GET: /Presentation
        [HttpGet]
        public IEnumerable<Presentation> Get()
        {
            return pl.ReadAll();
        }

        // GET /Presentation/5
        [HttpGet("{id}")]
        public Presentation Get(string id)
        {
            return pl.Read(id);
        }

        // POST /Presentation
        [HttpPost]
        public IActionResult Post([FromBody] Presentation value)
        {
            try
            {
                pl.Create(value);
                hub.Clients.All.SendAsync("PresentationCreate", value);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // PUT /Presentation
        [HttpPut]
        public void Put([FromBody] Presentation value)
        {
            pl.Update(value);
            hub.Clients.All.SendAsync("PresentationUpdate", value);
        }

        // DELETE /Presentation/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var toDelet = pl.Read(id);
            pl.Delete(id);
            hub.Clients.All.SendAsync("PresentationDelete", toDelet);
        }
    }
}
