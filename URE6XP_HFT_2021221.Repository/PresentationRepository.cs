using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Data;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Repository
{
    public class PresentationRepository : IPresentatonRepository
    {
        UnivercityDbContext db;
        public PresentationRepository(UnivercityDbContext db)
        {
            this.db = db;
        }
        public void Create(Presentation presentation)
        {
            db.Presentations.Add(presentation);
            db.SaveChanges();
        }

        public void Delete(string PresentationName)
        {
            var PresentationToDelet = Read(PresentationName);
            db.Presentations.Remove(PresentationToDelet);
            db.SaveChanges();
        }

        public IQueryable<Presentation> GetAll()
        {
            return db.Presentations;
        }

        public Presentation Read(string PresentationName)
        {
            return db.Presentations.FirstOrDefault(t => t.PresentationName == PresentationName);
        }

        public void Update(Presentation presentation)
        {
            var PresentationToUpdate = Read(presentation.PresentationName);
            PresentationToUpdate.Instructor = presentation.Instructor;
            PresentationToUpdate.LectureHall = presentation.LectureHall;
            db.SaveChanges();
        }
    }
}
