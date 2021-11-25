﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;
using URE6XP_HFT_2021221.Repository;

namespace URE6XP_HFT_2021221.Logic
{
    public class LectureHallLogic : ILectureHallLogic
    {
        ILectureHallRepository LectureHallRepository;

        public LectureHallLogic(ILectureHallRepository lectureHallRepository)
        {
            this.LectureHallRepository = lectureHallRepository;
        }
        public void Create(LectureHall lectureHall)
        {
            if (lectureHall.RoomNumber.Length < 5)
            {
                throw new ArgumentException("Room number cant be shorter thzen 6 caracter");
            }

            LectureHallRepository.Create(lectureHall);
        }

        public void Delete(string RoomNumber)
        {
            LectureHallRepository.Delete(RoomNumber);
        }

        public IEnumerable<string> InstructorsInLectureHall(string RoomNumber)
        {
            var q = LectureHallRepository.ReadALL()
                   .FirstOrDefault(t => t.RoomNumber == RoomNumber).Presentations;
            if (q.Count() > 0)
            {
                return from x in q select ((x)?.Instructor)?.Name;
            }
            return new List<string>() { "No instructor in this room" };

        }

        public LectureHall Read(string RoomNumber)
        {
            return LectureHallRepository.Read(RoomNumber);
        }

        public IEnumerable<LectureHall> ReadAll()
        {
            return LectureHallRepository.ReadALL();
        }

        public void Update(LectureHall lectureHall)
        {
            LectureHallRepository.Update(lectureHall);
        }

        
    }
}
