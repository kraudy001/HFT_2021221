using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Data;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Repository
{
    public class LectureHallRepository : ILectureHallRepository
    {
        UnivercityDbContext db;
        public LectureHallRepository(UnivercityDbContext db)
        {
            this.db = db;
        }

        public void Create(LectureHall lectureHall)
        {
            db.LectureHalls.Add(lectureHall);
            db.SaveChanges();
        }
        public LectureHall Read(string RoomNumber)
        {
            return db.LectureHalls.FirstOrDefault(t => t.RoomNumber == RoomNumber);
        }

        public IQueryable<LectureHall> ReadALL()
        {
            return db.LectureHalls;
        }

       
        public void Delete(string RoomNumber)
        {
            var LectureHallToDelete = Read(RoomNumber);
            db.LectureHalls.Remove(LectureHallToDelete);
            db.SaveChanges();
        }
        public void Update(LectureHall lectureHall)
        {
            var LectureHallToUpdate = Read(lectureHall.RoomNumber);
            LectureHallToUpdate.Presentations = lectureHall.Presentations;
            LectureHallToUpdate.Capacity = lectureHall.Capacity;
            db.SaveChanges();
        }
    }
}
