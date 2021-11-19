using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Repository
{
    public interface ILectureHallRepository
    {
        void Create(LectureHall lectureHall);
        void Delete(string RoomNumber);
        IQueryable<LectureHall> ReadALL();
        LectureHall Read(string RoomNumber);
        void Update(LectureHall lectureHall);
    }
}
