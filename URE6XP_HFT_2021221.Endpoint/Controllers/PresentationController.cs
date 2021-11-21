using Microsoft.AspNetCore.Mvc;
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

        public PresentationController(IPresentationLogic presentationLogic)
        {
            this.pl = presentationLogic;
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
        public void Post([FromBody] Presentation value)
        {
            pl.Create(value);
        }

        // PUT /Presentation
        [HttpPut]
        public void Put([FromBody] Presentation value)
        {
            pl.Update(value);
        }

        // DELETE /Presentation/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            pl.Delete(id);
        }
    }
}
