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
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IInstructorLogic il;
        ILectureHallLogic ll;
        IPresentationLogic pl;

        public StatController(IInstructorLogic instructorLogic,ILectureHallLogic lectureHallLogic, IPresentationLogic presentationLogic)
        {
            this.il = instructorLogic;
            this.ll = lectureHallLogic;
            this.pl = presentationLogic;
        }

        // GET: /Stat/PresentetionsAndNeptunIDs
        [HttpGet]
        public IEnumerable<string> GetPresentetionsAndNeptunIDs()
        {
            return pl.PresentetionsAndNeptunIDs();
        }
        // GET: /Stat/GetInstructorsInLectureHallTest/5
        [HttpGet("{roomNumber}")]
        public IEnumerable<string> GetInstructorsInLectureHallTest(string roomNumber)
        {
            return ll.InstructorsInLectureHall(roomNumber);
        }
        // GET: /Stat/WitchLacturesTeachisAnInstructorInARoom/5/5
        [HttpGet("{roomNumberPluszNeptunId}")]
        public IEnumerable<string> GetWitchLacturesTeachisAnInstructorInARoom(string roomNumberPluszNeptunId)
        {
            string[] struff = roomNumberPluszNeptunId.Split(" ");
            return pl.WitchLacturesTeachisAnInstructorInARoom(struff[0],struff[1]);
        }
        // GET: /Stat/HowManyRoomAnInstructorTeachisIn/5
        [HttpGet("{neptunId}")]
        public int GetHowManyRoomAnInstructorTeachisIn(string neptunId)
        {
            return il.HowManyRoomAnInstructorTeachisIn(neptunId);
        }
        // GET: /Stat/PresentetionsAndNeptunIDs/5
        [HttpGet("{NeptunId}")]
        public IEnumerable<string> RoomsThatAnInstructorHasLactures(string NeptunId)
        {
            return il.RoomsThatAnInstructorHasLactures(NeptunId);
        }

    }
}
