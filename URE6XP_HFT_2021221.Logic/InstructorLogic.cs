using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;
using URE6XP_HFT_2021221.Repository;

namespace URE6XP_HFT_2021221.Logic
{
    public class InstructorLogic : IInstructorLogic
    {
        IInstructorRepository InstructorRepository;

        public InstructorLogic(IInstructorRepository instructorRepository)
        {
            this.InstructorRepository = instructorRepository;
        }
        public void Create(Instructor instructor)
        {

            if (instructor.NeptunId.Length != 6)
            {
                throw new ArgumentException("The length of neptun id must be 6");
            }
            if(instructor.Name.Length < 3)
            {
                throw new ArgumentException("Length of name must be at least 3");
            }
            InstructorRepository.Create(instructor);
        }

        public void Delete(string name)
        {
            InstructorRepository.Delete(name);
        }

        public int HowManyRoomAnInstructorTeachisIn(string NeptunId)
        {
            var q = InstructorRepository.ReadALL().FirstOrDefault(i => i.NeptunId == NeptunId).Presentations;
            var q1 = from x in q group x by x.RoomNumber;
            return q1.Count();
        }

        public Instructor Read(string NeptunID)
        {
            return InstructorRepository.Read(NeptunID);
        }

        public IEnumerable<Instructor> ReadAll()
        {
            return InstructorRepository.ReadALL();
        }

        public IEnumerable<string> RoomsThatAnInstructorHasLactures(string NeptunId)
        {
            return from x in InstructorRepository.ReadALL()
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
