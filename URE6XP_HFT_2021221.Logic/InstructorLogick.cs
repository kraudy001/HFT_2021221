using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;
using URE6XP_HFT_2021221.Repository;

namespace URE6XP_HFT_2021221.Logic
{
    class InstructorLogick : IInstructorLogic
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

        public Instructor Read(string name)
        {
            return InstructorRepository.Read(name);
        }

        public void Update(Instructor instructor)
        {
            InstructorRepository.Update(instructor);
        }
    }
}
