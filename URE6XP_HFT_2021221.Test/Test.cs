﻿using Moq;
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

            Instructor KovacsAndras = new Instructor() { Name = "Kovács András", NeptunId = "DFVW5VD"};
            Instructor DrHolynkaPeter = new Instructor() { Name = "Dr.Holynka Péter", NeptunId = "553KJA" };
            Instructor DurczyLevente = new Instructor() { Name = "Durczy Lenevte", NeptunId = "DF666D" };
            Instructor SimonNagyGabriella = new Instructor() { Name = "Simon-Nagy Gabriella", NeptunId = "LADDEE" };
            Instructor DrBujdosoLaszlo = new Instructor() { Name = "Dr.Bujdosó László", NeptunId = "KKKVAN" };
            Instructor GyorineKontorEva = new Instructor() { Name = "Győriné Kontor Éva", NeptunId = "ANGOL1" };


            LectureHall BAF01 = new LectureHall() { RoomNumber = "BA.F.01"};
            LectureHall BA132 = new LectureHall() { RoomNumber = "BA.1.32.Audmax"};
            LectureHall BA115 = new LectureHall() { RoomNumber = "BA.1.15"};
            LectureHall BA210 = new LectureHall() { RoomNumber = "BA.2.10"};
            LectureHall BC3304 = new LectureHall() { RoomNumber = "BC.3.304"};



            var HFT = new Presentation() { PresentationName = "HFT", LectureHall = BAF01, RoomNumber = BAF01.RoomNumber, Instructor = KovacsAndras, InstrctoreName = KovacsAndras.Name };
            var SZTF1 = new Presentation() { PresentationName = "SZTF1", LectureHall = BA132, RoomNumber = BA132.RoomNumber, Instructor = KovacsAndras, InstrctoreName = KovacsAndras.Name };
            var Archi1=  new Presentation() { PresentationName = "Archi 1", LectureHall = BAF01, RoomNumber = BAF01.RoomNumber, Instructor = DurczyLevente, InstrctoreName = DurczyLevente.Name };
            var VIR = new Presentation() { PresentationName = "VIR", LectureHall = BC3304, RoomNumber = BC3304.RoomNumber, Instructor = DrHolynkaPeter, InstrctoreName = DrHolynkaPeter.Name };
            var Menedzsment = new Presentation() { PresentationName = "Menedzsment alapjai", LectureHall = BA210, RoomNumber = BA210.RoomNumber, Instructor = DrBujdosoLaszlo, InstrctoreName = DrBujdosoLaszlo.Name };
            var Angol1 = new Presentation() { PresentationName = "Angol Szaknyel A", LectureHall = BC3304, RoomNumber = BC3304.RoomNumber, Instructor = GyorineKontorEva, InstrctoreName = GyorineKontorEva.Name };

            BAF01.Presentations = new List<Presentation> { HFT, Archi1 };
            BA132.Presentations = new List<Presentation> { SZTF1 };
            BA115.Presentations = new List<Presentation> { };
            BA210.Presentations = new List<Presentation> { Menedzsment };
            BC3304.Presentations = new List<Presentation> { VIR, Angol1 };

            KovacsAndras.Presentations = new List<Presentation> { HFT, SZTF1 };
            DrHolynkaPeter.Presentations = new List<Presentation> { VIR };
            DurczyLevente.Presentations = new List<Presentation> { Archi1 };
            SimonNagyGabriella.Presentations = new List<Presentation> { };
            DrBujdosoLaszlo.Presentations = new List<Presentation> { Menedzsment };
            GyorineKontorEva.Presentations = new List<Presentation> { Angol1 };

            var lectureHalls = new List<LectureHall>() { BA115, BA132, BA210, BAF01, BC3304 }.AsQueryable();
            mockLectureHallRepository.Setup((t) => t.ReadALL()).Returns(lectureHalls);

            var instructirs = new List<Instructor>() { KovacsAndras, DrBujdosoLaszlo, DrHolynkaPeter, SimonNagyGabriella, DurczyLevente, GyorineKontorEva }.AsQueryable();
            mockInstructorLogicRepositroy.Setup((t) => t.ReadALL()).Returns(instructirs);
            mockInstructorLogicRepositroy.Setup((t) => t.Read(It.IsAny<string>())).Returns(instructirs.FirstOrDefault(x => x.NeptunId == It.IsAny<string>()));

            var presentations = new List<Presentation>() { HFT,SZTF1,Archi1,VIR,Menedzsment,Angol1 }.AsQueryable();
            mockPresentationRepository.Setup((t) => t.ReadALL()).Returns(presentations);



            lectureHallLogic = new LectureHallLogic(mockLectureHallRepository.Object);
            instructorLogic = new InstructorLogic(mockInstructorLogicRepositroy.Object);
            presentationLogic = new PresentationLogic(mockPresentationRepository.Object);
        }

        [Test]
        public void PresentetionsAndNeptunIDsTest()
        {
            //ACT

            var resoult = presentationLogic.PresentetionsAndNeptunIDs();

            //ASSERT

            var expected = new List<string>() { "HFT DFVW5VD", "SZTF1 DFVW5VD", "Archi 1 DF666D", "VIR 553KJA", "Menedzsment alapjai KKKVAN", "Angol Szaknyel A ANGOL1" };

            Assert.That(resoult, Is.EquivalentTo(expected));
        }

        [Test]
        public void WitchLacturesTeachisAnInstructorInARoomTest()
        {
            //ACT

            var resoult = presentationLogic.WitchLacturesTeachisAnInstructorInARoom("BA.F.01", "DFVW5VD");

            //ASSERT

            var expected = new List<string>() { "HFT" };

            Assert.That(resoult, Is.EquivalentTo(expected));
        }

        [Test]
        public void InstructorsInLectureHallTest()
        {
            //ACT

            var resoult = lectureHallLogic.InstructorsInLectureHall("BC.3.304");

            //ASSERT

            var expected = new List<string>() { "Győriné Kontor Éva", "Dr.Holynka Péter" };

            Assert.That(resoult, Is.EquivalentTo(expected));
        }

        [TestCase("DFVW5VD", 2)]
        [TestCase("ANGOL1", 1)]
        public void HowManyRoomAnInstructorTeachisInTest(string neptunId, int expected)
        {
            //ACT

            int resoult = instructorLogic.HowManyRoomAnInstructorTeachisIn(neptunId);

            //ASSERT

            Assert.That(resoult, Is.EqualTo(expected));
        }
        [Test]
        public void RoomsThatAnInstructorHasLacturesTest()
        {
            //ACT

            var resoult = instructorLogic.RoomsThatAnInstructorHasLactures("ANGOL1");

            //ASSERT

            var expected = new List<string>() { "BC.3.304"};

            Assert.That(resoult, Is.EquivalentTo(expected));
        }
        [Test]
        public void PresentatonsCreateTest()
        { 
            Assert.That(

                () => presentationLogic.Create(new Presentation { PresentationName = "NO", InstrctoreName = "Még Egy Előadó Név", RoomNumber = "AB.1.12" }),

                Throws.TypeOf<ArgumentException>()
                
                );
        }
        [Test]
        public void InstructorCreateTest()
        {
            Assert.That(

                () => instructorLogic.Create(new Instructor { NeptunId = "NOT6",  Name = "Még Egy Előadó Név"}),

                Throws.TypeOf<ArgumentException>()

                );
        }
        [Test]
        public void LectureHallrCreateTest()
        {
            Assert.That(

                () => lectureHallLogic.Create(new LectureHall { RoomNumber = "YES" }),

                Throws.TypeOf<ArgumentException>()

                );
        }


        //[Test]
        //public void InstructorUpdate()
        //{
        //    //ACT
        //    var valamik = instructorLogic.Read("DFVW5VD");


        //    instructorLogic.Update(new Instructor() { Name = "Dr.Kovács András", NeptunId = "DFVW5VD" });

        //    //ASSERT

        //    Assert.That("Dr.Kovács András", Is.EqualTo(instructorLogic.Read("DFVW5VD").Name));   //hát én ezt nem értem :(
        //}

        [Test]
        public void LectureHallLogicDeleteTest()
        {
            lectureHallLogic.Delete("BA.1.15");

            Assert.That(lectureHallLogic.Read("BA.1.15"), Is.Null);
        }        

        [Test]
        public void InstructorLogicDeletTest()
        {
            lectureHallLogic.Delete("DFVW5VD");

            Assert.That(lectureHallLogic.Read("DFVW5VD"), Is.Null);
        }
    }
}
