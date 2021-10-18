using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Repository
{
    interface IPresentatonRepository
    {
        void Create(Presentation presentation);
        void Delete(string PresentationName);
        IQueryable<Presentation> GetAll();
        Presentation Read(string PresentationName);
        void Update(Presentation presentation);
    }
}
