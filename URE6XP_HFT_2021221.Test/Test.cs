using Moq;
using NUnit.Framework;
using System;
using URE6XP_HFT_2021221.Logic;
using URE6XP_HFT_2021221.Models;
using URE6XP_HFT_2021221.Repository;

namespace URE6XP_HFT_2021221.Test
{
    [TestFixture]
    public class Test
    {
        PresentationLogick presentationLogick;
        [SetUp]
        public void Init()
        {
            var mockCarRepository = new Mock<IPresentationRepository>();

            Instructor KovacsAndras = new Instructor() { Name = "Kovács András", NeptunId = "DFVW5VD" };
            Instructor DrHolynkaPeter = new Instructor() { Name = "Dr.Holynka Péter", NeptunId = "553KJA" };
            Instructor DurczyLevente = new Instructor() { Name = "Durczy Lenevte", NeptunId = "DF666D" };
            Instructor SimonNagyGabriella = new Instructor() { Name = "Simon-Nagy Gabriella", NeptunId = "LADDEE" };
            Instructor DrBujdosoLaszlo = new Instructor() { Name = "Dr.Bujdosó László", NeptunId = "KKKVAN" };
            Instructor GyorineKontorEva = new Instructor() { Name = "Győriné Kontor Éva", NeptunId = "ANGOL1" };

            LectureHall BAF01 = new LectureHall() { RoomNumber = "BA.F.01" };
            LectureHall BA132 = new LectureHall() { RoomNumber = "BA.1.32.Audmax" };
            LectureHall BA115 = new LectureHall() { RoomNumber = "BA.1.15" };
            LectureHall BA210 = new LectureHall() { RoomNumber = "BA.2.10" };
            LectureHall BC3304 = new LectureHall() { RoomNumber = "BC.3.304" };


            Presentation HFT = new Presentation() { PresentationName = "HFT", RoomNumber = "BA.F.01", InstrctoreName = "DFVW5VD" };
            Presentation SZTF1 = new Presentation() { PresentationName = "SZTF1", RoomNumber = "BA.1.32.Audmax", InstrctoreName = "DFVW5VD" };
            Presentation ARCHI1 = new Presentation() { PresentationName = "Archi 1", RoomNumber = "BA.F.01", InstrctoreName = "DF666D" };
            Presentation VIR = new Presentation() { PresentationName = "VIR", RoomNumber = "BC.3.304", InstrctoreName = "553KJA" };
            Presentation Menedzsment = new Presentation() { PresentationName = "Menedzsment alapjai", RoomNumber = "BA.2.10", InstrctoreName = "KKKVAN" };
            Presentation AngolSzaknyelv = new Presentation() { PresentationName = "Angol Szaknyel A", RoomNumber = "BC.3.304", InstrctoreName = "ANGOL1" };
        }

    }
}
