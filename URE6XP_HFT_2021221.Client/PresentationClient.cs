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
        public static void PresentationGetALL(RestService rest)
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
        public static void PresentationGetOne(RestService rest)
        {
            Console.WriteLine("What is the name of an presentation");

            string name = Console.ReadLine();

            Instructor resoult = rest.GetSingle<Instructor>("Presentation/" + name);

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
        public static void PresentationCreate(RestService rest)
        {
            Console.WriteLine("Pleas type in presentation name");
            Presentation presentation = new Presentation() {  InstrctoreName = (Console.ReadLine()) };

            Console.WriteLine("Pleas type in room number");
            presentation.RoomNumber = Console.ReadLine();

            Console.WriteLine("Pleas type in instructor name");
            presentation.InstrctoreName = Console.ReadLine();

            try
            {
                rest.Post<Presentation>(presentation, "Presentation");
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("Would you like to try agen? \n Then type YES");
                if (Console.ReadLine() == "YES")
                {
                    PresentationCreate(rest);
                }
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public static void PresentationUpdate(RestService rest)
        {
            Console.WriteLine("Pleas type in presentation name");
            Presentation presentation = new Presentation() { PresentationName = (Console.ReadLine()) };

            Console.WriteLine("Pleas type in room number id");
            presentation.RoomNumber = Console.ReadLine();
            
            Console.WriteLine("Pleas type in instructor");
            presentation.InstrctoreName = Console.ReadLine();

            rest.Put<Presentation>(presentation, "Presentation");


            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public static void PresentationDelete(RestService rest)
        {
            Console.WriteLine("Ples type in presentation name to delet");
            string toDelet = Console.ReadLine();

            rest.Delete(toDelet, "Presentation");

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
    }
}
