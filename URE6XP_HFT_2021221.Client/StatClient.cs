using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URE6XP_HFT_2021221.Client
{
    class StatClient
    {
        RestService rest;
        public StatClient(RestService rest)
        {
            this.rest = rest;
        }        
        public void GetPresentetionsAndNeptunIDs()
        {
            List<string> list = rest.Get<string>("Stat/GetPresentetionsAndNeptunIDs");
            Console.WriteLine("Presentation and neptun ID pairs");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public void GetInstructorsInLectureHallTest()
        {
            Console.WriteLine("Choos a room");

            string roomNumber = Console.ReadLine();

            List<string> list = rest.Get<string>("Stat/GetInstructorsInLectureHallTest/" + roomNumber);
            Console.WriteLine("Instructors in " + roomNumber);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public void GetWitchLacturesTeachisAnInstructorInARoom()
        {
            Console.WriteLine("Choos a room");

            string roomNumber = Console.ReadLine();

            Console.WriteLine("Choos a neptun id");

            string neptunId = Console.ReadLine();

            string stuff = roomNumber + " " + neptunId;

            List<string> list = rest.Get<string>("Stat/GetWitchLacturesTeachisAnInstructorInARoom/" + stuff);
            Console.WriteLine("Presentations in " + roomNumber + " room, by " + neptunId);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public void GetHowManyRoomAnInstructorTeachisIn()
        {
            Console.WriteLine("Choos a neptun id");

            string neptunId = Console.ReadLine();

            int resoult = rest.GetSingle<int>("Stat/GetHowManyRoomAnInstructorTeachisIn/" + neptunId);
            if (resoult == -1)
            {
                Console.WriteLine(neptunId + " instructor does not exist");
            }
            else if (resoult == 0)
            {
                Console.WriteLine(neptunId + " instructor has no presentation");
            }
            else
            {
                Console.WriteLine("Instructors whit " + neptunId + " neptun id teachis in " + resoult + " room");
            }
            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public void RoomsThatAnInstructorHasLactures()
        {
            Console.WriteLine("Choos a neptun id");

            string neptunId = Console.ReadLine();

            List<string> list = rest.Get<string>("Stat/RoomsThatAnInstructorHasLactures/" + neptunId);
            Console.WriteLine("Rooms where the instructor whit " + neptunId +" neptun id works in");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }

    }
}
