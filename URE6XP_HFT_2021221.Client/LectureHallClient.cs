using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Client
{
    class LectureHallClient
    {
        public static void LectureHallGetALL(RestService rest)
        {
            Console.WriteLine("All Lecture Hall Listed");

            var list = rest.Get<LectureHall>("LectureHall");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public static void LectureHallGetOne(RestService rest)
        {
            Console.WriteLine("What is the room number of an lecture hall");

            string roomNumber = Console.ReadLine();

            Instructor resoult = rest.GetSingle<Instructor>("LectureHall/" + roomNumber);

            Console.WriteLine("The looked for lecture hall");
            if (resoult != null)
            {
                Console.WriteLine(resoult);
            }
            else
            {
                Console.WriteLine("Unknown room number");
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public static void LectureHallCreate(RestService rest)
        {
            Console.WriteLine("Pleas type in room number");
            LectureHall lectureHall  = new LectureHall() {  RoomNumber = (Console.ReadLine()) };

            try
            {
                rest.Post<LectureHall>(lectureHall, "LectureHall");
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("Would you like to try agen? \n Then type YES");
                if (Console.ReadLine() == "YES")
                {
                    LectureHallCreate(rest);
                }
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public static void LectureHallUpdate(RestService rest)
        {
            Console.WriteLine("Pleas type in RoomNumber");
            LectureHall room = new LectureHall() {  RoomNumber = (Console.ReadLine()) };

            Console.WriteLine("Pleas type in room capacity");
            room.Capacity = int.Parse(Console.ReadLine());

            rest.Put<LectureHall>(room, "LectureHall");


            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public static void LectureHallDelete(RestService rest)
        {
            Console.WriteLine("Ples type in room number to delet");
            string toDelet = Console.ReadLine();

            rest.Delete(toDelet, "LectureHall");

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
    }
}
