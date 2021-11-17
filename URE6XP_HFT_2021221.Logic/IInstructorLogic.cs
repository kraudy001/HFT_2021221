using System;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Logic
{
    public interface IInstructorLogic
    {
        void Create(Instructor instructor);
        void Delete(string name);
        Instructor Read(string name);
        void Update(Instructor instructor);
    }
}
