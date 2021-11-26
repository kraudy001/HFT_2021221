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

            LectureHallClient lectureHallClient = new LectureHallClient(rest);
            PresentationClient presentationClient = new PresentationClient(rest);
            InstructorClient instructorClient = new InstructorClient(rest);



            var Instructor = new ConsoleMenu()
            .Add("Get ALL instructor", () => instructorClient.InstructorGetALL())
            .Add("Get one instructor by neptun id", () => instructorClient.InstructorGetOne())
            .Add("Create an instructor", () => instructorClient.InstructorCreate())
            .Add("Update an instructor", () => instructorClient.InstructorUpdate())
            .Add("Delete an instructor", () => instructorClient.InstructorDelete())
            .Add("Back to main menu", ConsoleMenu.Close);

            var Presentation = new ConsoleMenu()
            .Add("Get ALL presentation", () => presentationClient.PresentationGetALL())
            .Add("Get one presentation by presentation name", () => presentationClient.PresentationGetOne())
            .Add("Create a presentation", () => presentationClient.PresentationCreate())
            .Add("Update a presentation", () => presentationClient.PresentationUpdate())
            .Add("Delete a presentation", () => presentationClient.PresentationDelete())
            .Add("Back to menu", ConsoleMenu.Close);

            var LectureHall = new ConsoleMenu()
            .Add("Get ALL lecture hall", () => lectureHallClient.LectureHallGetALL())
            .Add("Get one lecture hall by room number", () => lectureHallClient.LectureHallGetOne())
            .Add("Create a lecture hall", () => lectureHallClient.LectureHallCreate())
            .Add("Update a lecture hall", () => lectureHallClient.LectureHallUpdate())
            .Add("Delete a lecture hall", () => lectureHallClient.LectureHallDelete())
            .Add("Back to menu", ConsoleMenu.Close);

            var NonCRUD = new ConsoleMenu()
                .Add("Returns presentations and instructor neptunid pairs", () => StatClient.GetPresentetionsAndNeptunIDs(rest))
                .Add("Returns all instructors in room", () => StatClient.GetInstructorsInLectureHallTest(rest))
                .Add("Return wich lectrus held in a room, by one instructor", () => StatClient.GetWitchLacturesTeachisAnInstructorInARoom(rest))
                .Add("1Returns how many rooms an instructro teachis in", () => StatClient.GetHowManyRoomAnInstructorTeachisIn(rest))
                .Add("Returns where those an instructro teaches in", () => StatClient.RoomsThatAnInstructorHasLactures(rest))
                .Add("Back to menu", ConsoleMenu.Close);



            var menu = new ConsoleMenu()
              .Add("Instructor commands", Instructor.Show)
              .Add("Presentation commands", Presentation.Show)
              .Add("Lecture Hall commands", LectureHall.Show)
              .Add("Special methods", NonCRUD.Show)
              .Add("Exit", () => Environment.Exit(0));

            menu.Show();
        }
     
        
    }
}
