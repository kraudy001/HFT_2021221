using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using URE6XP_HFT_2021221.Logic;
using URE6XP_HFT_2021221.Models;
using URE6XP_HFT_2021221.Repository;

namespace URE6XP_HFT_2021221.Test
{
    [TestFixture]
    public class Test
    {
        IPresentationLogic presentationLogic;
        IInstructorLogic instructorLogic;
        ILectureHallLogic lectureHallLogic;
        [SetUp]
        public void Init()
        {
            var mockPresentationRepository = new Mock<IPresentationRepository>();
            var mockInstructorLogicRepositroy = new Mock<IInstructorRepository>();
            var mockLectureHallRepository = new Mock<ILectureHallRepository>();

            Instructor KovacsAndras = new Instructor() { Name = "Kovács András", NeptunId = "DFVW5VD" };
            Instructor DrHolynkaPeter = new Instructor() { Name = "Dr.Holynka Péter", NeptunId = "553KJA" };
            Instructor DurczyLevente = new Instructor() { Name = "Durczy Lenevte", NeptunId = "DF666D" };
            Instructor SimonNagyGabriella = new Instructor() { Name = "Simon-Nagy Gabriella", NeptunId = "LADDEE" };
            Instructor DrBujdosoLaszlo = new Instructor() { Name = "Dr.Bujdosó László", NeptunId = "KKKVAN" };
            Instructor GyorineKontorEva = new Instructor() { Name = "Győriné Kontor Éva", NeptunId = "ANGOL1" };

            var instructirs = new List<Instructor>() { KovacsAndras, DrBujdosoLaszlo, DrHolynkaPeter, SimonNagyGabriella, DurczyLevente, GyorineKontorEva }.AsQueryable();

            mockInstructorLogicRepositroy.Setup((t) => t.ReadALL()).Returns(instructirs);

            LectureHall BAF01 = new LectureHall() { RoomNumber = "BA.F.01" , Presentations = new List<Presentation> { } };
            LectureHall BA132 = new LectureHall() { RoomNumber = "BA.1.32.Audmax" , Presentations = new List<Presentation> { } };
            LectureHall BA115 = new LectureHall() { RoomNumber = "BA.1.15", Presentations = new List<Presentation> { } };
            LectureHall BA210 = new LectureHall() { RoomNumber = "BA.2.10", Presentations = new List<Presentation> { } };
            LectureHall BC3304 = new LectureHall() { RoomNumber = "BC.3.304", Presentations = new List<Presentation> { } };

            var lectureHalls = new List<LectureHall>() { BA115, BA132, BA210, BAF01, BC3304 }.AsQueryable();

            mockLectureHallRepository.Setup((t) => t.ReadALL()).Returns(lectureHalls);

            var HFT = new Presentation() { PresentationName = "HFT", LectureHall = BAF01, RoomNumber = BAF01.RoomNumber, Instructor = KovacsAndras, InstrctoreName = KovacsAndras.Name };
            var SZTF1 = new Presentation() { PresentationName = "SZTF1", LectureHall = BA132, RoomNumber = BA132.RoomNumber, Instructor = KovacsAndras, InstrctoreName = KovacsAndras.Name };
            var Archi1=  new Presentation() { PresentationName = "Archi 1", LectureHall = BAF01, RoomNumber = BAF01.RoomNumber, Instructor = DurczyLevente, InstrctoreName = DurczyLevente.Name };
            var VIR = new Presentation() { PresentationName = "VIR", LectureHall = BC3304, RoomNumber = BC3304.RoomNumber, Instructor = DrHolynkaPeter, InstrctoreName = DrHolynkaPeter.Name };
            var Menedzsment = new Presentation() { PresentationName = "Menedzsment alapjai", LectureHall = BA210, RoomNumber = BA210.RoomNumber, Instructor = DrBujdosoLaszlo, InstrctoreName = DrBujdosoLaszlo.Name };
            var Angol1 = new Presentation() { PresentationName = "Angol Szaknyel A", LectureHall = BC3304, RoomNumber = BC3304.RoomNumber, Instructor = GyorineKontorEva, InstrctoreName = GyorineKontorEva.Name };

            var presentations = new List<Presentation>() { HFT,SZTF1,Archi1,VIR,Menedzsment,Angol1 }.AsQueryable();

            mockPresentationRepository.Setup((t) => t.ReadALL()).Returns(presentations);

            presentationLogic = new PresentationLogic(mockPresentationRepository.Object);
        }

        [Test]
        public void PresentetionsAndNeptunIDsTest()
        {
            //ACT
            var resoult = presentationLogic.PresentetionsAndNeptunIDs();
            //ASSERT
            var expected = new List<string>() { "HFT DFVW5VD", "SZTF1 DFVW5VD", "Archi 1 DF666D", "VIR 553KJA", "Menedzsment alapjai KKKVAN", "Angol Szaknyel A ANGOL1" };
            Assert.That(resoult, Is.EqualTo(expected));
        }

        [Test]
        public void WitchLacturesTeachisAnInstructorInARoomTest()
        {
            //ACT
            var resoult = presentationLogic.WitchLacturesTeachisAnInstructorInARoom("BA.F.01", "DFVW5VD");
            //ASSERT
            var expected = new List<string>() { "HFT" };
            Assert.That(resoult, Is.EqualTo(expected));
        }

    }
}
