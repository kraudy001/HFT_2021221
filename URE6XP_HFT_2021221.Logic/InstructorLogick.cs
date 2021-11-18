using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;
using URE6XP_HFT_2021221.Repository;

namespace URE6XP_HFT_2021221.Logic
{
    public class InstructorLogick : IInstructorLogic
    {
        IInstructorRepository InstructorRepository;
        public void Create(Instructor instructor)
        {
            InstructorRepository.Create(instructor);
        }

        public void Delete(string name)
        {
            InstructorRepository.Delete(name);
        }

        public int HowManyRoomAnInstructorTeachisIn(string NeptunId)
        {
            var q = InstructorRepository.GetAll().FirstOrDefault(i => i.NeptunId == NeptunId).Presentations;
            var q1 = from x in q group x by x.RoomNumber;
            return q1.Count();
        }

        public Instructor Read(string name)
        {
            return InstructorRepository.Read(name);
        }

        public IEnumerable<Instructor> ReadAll()
        {
            return InstructorRepository.GetAll();
        }

        public IEnumerable<string> RoomsThatAnInstructorHasLactures(string NeptunId)
        {
            return from x in InstructorRepository.GetAll()
                   .FirstOrDefault(i => i.NeptunId == NeptunId)
                   .Presentations 
                   select x.LectureHall.RoomNumber;
        }

        public void Update(Instructor instructor)
        {
            InstructorRepository.Update(instructor);
        }
    }
}
