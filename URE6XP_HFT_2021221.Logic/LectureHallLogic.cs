using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;
using URE6XP_HFT_2021221.Repository;

namespace URE6XP_HFT_2021221.Logic
{
    class LectureHallLogic : ILectureHallLogic
    {
        ILectureHallRepository LectureHallRepository;
        public void Create(LectureHall lectureHall)
        {
            LectureHallRepository.Create(lectureHall);
        }

        public void Delete(string RoomNumber)
        {
            LectureHallRepository.Delete(RoomNumber);
        }

        public IEnumerable<string> InstructorsInLectureHall(string RoomNumber)
        {
            return from x in LectureHallRepository.GetAll()
                   .FirstOrDefault(t => t.RoomNumber == RoomNumber)
                   .Presentations select x.Instructor.Name;           
        }

        public LectureHall Read(string RoomNumber)
        {
            return LectureHallRepository.Read(RoomNumber);
        }

        public void Update(LectureHall lectureHall)
        {
            LectureHallRepository.Update(lectureHall);
        }
    }
}
