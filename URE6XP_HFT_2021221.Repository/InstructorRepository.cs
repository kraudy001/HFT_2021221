using System;
using System.Linq;
using URE6XP_HFT_2021221.Data;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        UnivercityDbContext db;
        public InstructorRepository(UnivercityDbContext db)
        {
            this.db = db;
        }
        public void Create(Instructor instructor)
        {
            db.Instructors.Add(instructor);
            db.SaveChanges();
        }

        public void Delete(string NeptunId)
        {
            var InstructorRepositorylToDelete = Read(NeptunId);
            db.Instructors.Remove(InstructorRepositorylToDelete);
            db.SaveChanges();
        }

        public IQueryable<Instructor> GetAll()
        {
            return db.Instructors;
        }

        public Instructor Read(string NeptunId)
        {
            return db.Instructors.FirstOrDefault(t => t.NeptunId == NeptunId);
        }

        public void Update(Instructor instructor)
        {
            var InstructorRepositorylToUpdate = Read(instructor.NeptunId);
            InstructorRepositorylToUpdate.Name = instructor.Name;
            InstructorRepositorylToUpdate.Presentations = instructor.Presentations;
            db.SaveChanges();
        }
    }
}
