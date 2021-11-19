using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Repository
{
    public interface IInstructorRepository
    {
        void Create(Instructor instructor);
        void Delete(string NeptunId);
        IQueryable<Instructor> ReadALL();
        Instructor Read(string NeptunId);
        void Update(Instructor instructor);
    }
}
