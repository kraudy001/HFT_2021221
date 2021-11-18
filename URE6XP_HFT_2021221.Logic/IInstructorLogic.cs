using System;
using System.Collections.Generic;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Logic
{
    public interface IInstructorLogic
    {
        void Create(Instructor instructor);
        void Delete(string name);
        Instructor Read(string name);
        void Update(Instructor instructor);
        IEnumerable<Instructor> ReadAll();
        IEnumerable<string> RoomsThatAnInstructorHasLactures(string NeptunId);
        int HowManyRoomAnInstructorTeachisIn(string NeptunId);
    }
}
