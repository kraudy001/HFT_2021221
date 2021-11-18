using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;
using URE6XP_HFT_2021221.Repository;

namespace URE6XP_HFT_2021221.Logic
{
    public class PresentationLogick : IPresentationLogick
    {
        IPresentationRepository PresentatonRepository;
        public void Create(Presentation presentation)
        {
            PresentatonRepository.Create(presentation);
        }

        public void Delete(string PresentationName)
        {
            PresentatonRepository.Delete(PresentationName);
        }

        public IEnumerable<KeyValuePair<string, string>> PresentetionsAndNeptunIDs()
        {
            return from x in PresentatonRepository.GetAll() 
                   select new KeyValuePair<string, string>
                   (x.PresentationName, x.Instructor.NeptunId);
        }

        public Presentation Read(string PresentationName)
        {
            return PresentatonRepository.Read(PresentationName);
        }

        public IEnumerable<Presentation> ReadAll()
        {
            return PresentatonRepository.GetAll();
        }

        public void Update(Presentation presentation)
        {
            PresentatonRepository.Update(presentation);
        }
        public IEnumerable<string> WitchLacturesTeachisAnInstructorInARoom(string RoomNumber, string NeptunId)
        {
            return from x in PresentatonRepository.GetAll()
                     where x.LectureHall.RoomNumber == RoomNumber && x.Instructor.NeptunId == NeptunId
                     select x.PresentationName;
        }
    }
}
