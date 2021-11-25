using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Client
{
    class PresentationClient
    {
        RestService rest;
        public PresentationClient(RestService rest)
        {
            this.rest = rest;
        }
        public  void PresentationGetALL()
        {
            Console.WriteLine("All Presentation Listed");

            var list = rest.Get<Presentation>("Presentation");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public  void PresentationGetOne()
        {
            Console.WriteLine("What is the name of an presentation");

            string name = Console.ReadLine();

            Presentation resoult = rest.GetSingle<Presentation>("Presentation/" + name);

            Console.WriteLine("The looked for presentation");
            if (resoult != null)
            {
                Console.WriteLine(resoult);
            }
            else
            {
                Console.WriteLine("Unknown presentation name");
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public  void PresentationCreate()
        {
            Console.WriteLine("Pleas type in presentation name (minimum 4 caracter)");
            Presentation presentation = new Presentation() {  PresentationName = (Console.ReadLine()) };

            Console.WriteLine("Pleas type in room number");
            presentation.RoomNumber = Console.ReadLine();

            Console.WriteLine("Pleas type in instructor neptun id");
            presentation.InstrctoreNeptunId = Console.ReadLine();

            try
            {
                rest.Post<Presentation>(presentation, "Presentation");
            }
            catch (Exception)
            {

                Console.WriteLine("Presentation name must be minimum of 4 caracter");
                Console.WriteLine("Room or instructor don't exist");
                Console.WriteLine("Would you like to try agen? \n Then type YES");
                if (Console.ReadLine() == "YES")
                {
                    PresentationCreate();
                }
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public  void PresentationUpdate()
        {
            Console.WriteLine("Pleas type in presentation name");
            Presentation presentation = new Presentation() { PresentationName = (Console.ReadLine()) };

            Console.WriteLine("Pleas type in room number id");
            presentation.RoomNumber = Console.ReadLine();
            
            Console.WriteLine("Pleas type in instructor");
            presentation.InstrctoreNeptunId = Console.ReadLine();

            rest.Put<Presentation>(presentation, "Presentation");


            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public  void PresentationDelete()
        {
            Console.WriteLine("Ples type in presentation name to delet");
            string toDelet = Console.ReadLine();

            rest.Delete(toDelet, "Presentation");

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
    }
}
