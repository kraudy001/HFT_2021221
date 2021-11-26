﻿using Microsoft.AspNetCore.Mvc;
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
        public InstructorController(IInstructorLogic instructorLogic)
        {
            this.il = instructorLogic;
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
            il.Delete(id);
        }
    }
}