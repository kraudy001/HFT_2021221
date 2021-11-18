using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Logic
{
    public interface IPresentationLogick
    {
        void Create(Presentation presentation);
        void Delete(string PresentationName);
        Presentation Read(string PresentationName);
        void Update(Presentation presentation);
        IEnumerable<Presentation> ReadAll();
        IEnumerable<KeyValuePair<string, string>> PresentetionsAndNeptunIDs();
        IEnumerable<string> WitchLacturesTeachisAnInstructorInARoom(string RoomNumber, string NeptunId);
    }
}
