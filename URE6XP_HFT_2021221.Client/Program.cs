using ConsoleTools;
using System;
using URE6XP_HFT_2021221.Models;

namespace URE6XP_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu();

        }

        public static void Menu()
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:60173");


            var Instructor = new ConsoleMenu()
            .Add("Get ALL", () => InstructorClient.InstructorGetALL(rest))
            .Add("Get one", () => InstructorClient.InstructorGetOne(rest))
            .Add("Create", () => InstructorClient.InstructorCreate(rest))
            .Add("Update", () => InstructorClient.InstructorUpdate(rest))
            .Add("Delete", () => InstructorClient.InstructorDelete(rest))
            .Add("Back to menu", ConsoleMenu.Close);

            var Presentation = new ConsoleMenu()
            .Add("Get ALL", () => PresentationClient.PresentationGetALL(rest))
            .Add("Get one", () => PresentationClient.PresentationGetOne(rest))
            .Add("Create", () => PresentationClient.PresentationCreate(rest))
            .Add("Update", () => PresentationClient.PresentationUpdate(rest))
            .Add("Delete", () => PresentationClient.PresentationDelete(rest))
            .Add("Back to menu", ConsoleMenu.Close);

            var LectureHall = new ConsoleMenu()
            .Add("Get ALL", () => LectureHallClient.LectureHallGetALL(rest))
            .Add("Get one", () => LectureHallClient.LectureHallGetOne(rest))
            .Add("Create", () => LectureHallClient.LectureHallCreate(rest))
            .Add("Update", () => LectureHallClient.LectureHallUpdate(rest))
            .Add("Delete", () => LectureHallClient.LectureHallDelete(rest))
            .Add("Back to menu", ConsoleMenu.Close);




            var menu = new ConsoleMenu()
              .Add("Instructor commands", Instructor.Show)
              .Add("Presentation commands", Presentation.Show)
              .Add("Lecture Hall commands", LectureHall.Show)
              .Add("Fuck", () => FUCKYOU())
              .Add("Exit", () => Environment.Exit(0));

            menu.Show();
        }
      
        public static void FUCKYOU()
        {
            Console.WriteLine("You asked for it\n\n\n"); // első próbálkozások :)
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("FUCK YOUUUUUUUU !!!4!!4!negy!!!\n\n\n");
            Console.WriteLine("Pleas hit enter to select an other option");
            Console.ReadLine();
        }
        
    }
}
