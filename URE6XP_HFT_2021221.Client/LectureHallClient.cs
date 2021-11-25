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
        RestService rest;
        public LectureHallClient(RestService rest)
        {
            this.rest = rest;
        }
        public  void LectureHallGetALL()
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
        public  void LectureHallGetOne()
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
        public  void LectureHallCreate()
        {
            Console.WriteLine("Pleas type in room number");
            LectureHall lectureHall  = new LectureHall() {  RoomNumber = (Console.ReadLine()) };

            Console.WriteLine("Pleas type in room capacity");
            lectureHall.Capacity = int.Parse(Console.ReadLine());
            
            try
            {
                rest.Post<LectureHall>(lectureHall, "LectureHall");
            }
            catch (Exception)
            {

                Console.WriteLine("Room number mast be 6 or more caracter");
                Console.WriteLine("Would you like to try agen? \n Then type YES");
                if (Console.ReadLine() == "YES")
                {
                    LectureHallCreate();
                }
            }

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public  void LectureHallUpdate()
        {
            Console.WriteLine("Pleas type in RoomNumber");
            LectureHall room = new LectureHall() {  RoomNumber = (Console.ReadLine()) };

            Console.WriteLine("Pleas type in room capacity");
            room.Capacity = int.Parse(Console.ReadLine());

            rest.Put<LectureHall>(room, "LectureHall");


            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
        public  void LectureHallDelete()
        {
            Console.WriteLine("Ples type in room number to delet");
            string toDelet = Console.ReadLine();

            rest.Delete(toDelet, "LectureHall");

            Console.WriteLine("Pleas hit enter to select an other optino");
            Console.ReadLine();
        }
    }
}
