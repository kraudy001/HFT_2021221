using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Repository
{
    public interface IPresentationRepository
    {
        void Create(Presentation presentation);
        void Delete(string PresentationName);
        IQueryable<Presentation> ReadALL();
        Presentation Read(string PresentationName);
        void Update(Presentation presentation);
    }
}
