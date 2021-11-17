using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;
using URE6XP_HFT_2021221.Repository;

namespace URE6XP_HFT_2021221.Logic
{
    class PresentationLogick : IPresentationLogick
    {
        IPresentatonRepository PresentatonRepository;
        public void Create(Presentation presentation)
        {
            PresentatonRepository.Create(presentation);
        }

        public void Delete(string PresentationName)
        {
            PresentatonRepository.Delete(PresentationName);
        }

        public Presentation Read(string PresentationName)
        {
            return PresentatonRepository.Read(PresentationName);
        }

        public void Update(Presentation presentation)
        {
            PresentatonRepository.Update(presentation);
        }
    }
}
