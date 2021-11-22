using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Client
{
    class InstructorClient
    {
        public static void InstructorGetALL(RestService rest)
        {
            Console.WriteLine("All Instructor Listed");

            var list = rest.Get<Instructor>("Instructor");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public static void InstructorGetOne(RestService rest)
        {
            Console.WriteLine("What is the neptun id of an instructor");

            string neptunId = Console.ReadLine();

            Instructor resoult = rest.GetSingle<Instructor>("Instructor/" + neptunId);

            Console.WriteLine("The looked for instructor");
            if (resoult != null)
            {
                Console.WriteLine(resoult);
            }
            else
            {
                Console.WriteLine("Unknown neptun id");
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public static void InstructorCreate(RestService rest)
        {
            Console.WriteLine("Pleas type in instructor name");
            Instructor instructor = new Instructor() { Name = (Console.ReadLine()) };

            Console.WriteLine("Pleas type in instructor neptun id");
            instructor.NeptunId = Console.ReadLine();

            try
            {
                rest.Post<Instructor>(instructor, "Instructor");
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("Would you like to try agen? \n Then type YES");
                if (Console.ReadLine() == "YES")
                {
                    InstructorCreate(rest);
                }
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public static void InstructorUpdate(RestService rest)
        {
            Console.WriteLine("Pleas type in instructor name");
            Instructor instructor = new Instructor() { Name = (Console.ReadLine()) };

            Console.WriteLine("Pleas type in instructor neptun id");
            instructor.NeptunId = Console.ReadLine();

            rest.Put<Instructor>(instructor, "Instructor");


            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public static void InstructorDelete(RestService rest)
        {
            Console.WriteLine("Ples type in instructor neptun id to delet");
            string toDelet = Console.ReadLine();

            rest.Delete(toDelet, "Instructor");

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
    }
}
