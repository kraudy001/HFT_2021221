using Microsoft.EntityFrameworkCore;
using System;
using URE6XP_HFT_2021221.Models;


namespace URE6XP_HFT_2021221.Data
{
    public class UnivercityDbContext : DbContext
    {
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Presentation> Presentations { get; set; }
        public virtual DbSet<LectureHall> LectureHalls { get; set; }
        public UnivercityDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Databaes.mdf;Integrated Security=True";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Instructor>(entity =>
            //{
            //    entity.HasMany(instructor => instructor.Presentations)
            //    .WithOne(presentation => presentation.InstructorNeptunId)
            //    .HasForeignKey(presentation => presentation.InstructorNeptunId)
            //    .OnDelete(DeleteBehavior.Restrict);
            //});

            modelBuilder.Entity<Presentation>(entity =>
            {
                entity.HasOne(presentation => presentation.LectureHall)
                .WithMany(lectureHall => lectureHall.Presentations)
                .HasForeignKey(presentations => presentations.RoomNumber)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(presentation => presentation.Instructor)
                .WithMany(instructor => instructor.Presentations)
                .HasForeignKey(presentation => presentation.InstrctoreNeptunId)
                .OnDelete(DeleteBehavior.Cascade);
                
            });

            Instructor KovacsAndras = new Instructor() { Name = "Kovács András", NeptunId = "DFVW5VD" };
            Instructor DrHolynkaPeter = new Instructor() { Name = "Dr.Holynka Péter", NeptunId = "553KJA" };
            Instructor DurczyLevente = new Instructor() { Name = "Durczy Lenevte", NeptunId = "DF666D" };
            Instructor SimonNagyGabriella = new Instructor() { Name = "Simon-Nagy Gabriella", NeptunId = "LADDEE" };
            Instructor DrBujdosoLaszlo = new Instructor() { Name = "Dr.Bujdosó László", NeptunId = "KKKVAN" };
            Instructor GyorineKontorEva = new Instructor() { Name = "Győriné Kontor Éva", NeptunId = "ANGOL1" };

            LectureHall BAF01 = new LectureHall() { RoomNumber = "BA.F.01", Capacity = 100};
            LectureHall BA132 = new LectureHall() { RoomNumber = "BA.1.32.Audmax", Capacity = 666 };
            LectureHall BA115 = new LectureHall() { RoomNumber = "BA.1.15", Capacity = 10 };
            LectureHall BA210 = new LectureHall() { RoomNumber = "BA.2.10", Capacity = 50 };
            LectureHall BC3304 = new LectureHall() { RoomNumber = "BC.3.304", Capacity = 24 };


            Presentation HFT = new Presentation() { PresentationName = "HFT", RoomNumber = BAF01.RoomNumber, InstrctoreNeptunId = KovacsAndras.NeptunId };
            Presentation SZTF1 = new Presentation() { PresentationName = "SZTF1", RoomNumber = BA132.RoomNumber, InstrctoreNeptunId = KovacsAndras.NeptunId };
            Presentation ARCHI1 = new Presentation() { PresentationName = "Archi 1", RoomNumber = BAF01.RoomNumber, InstrctoreNeptunId = DurczyLevente.NeptunId };
            Presentation VIR = new Presentation() { PresentationName = "VIR", RoomNumber = BC3304.RoomNumber, InstrctoreNeptunId = DrHolynkaPeter.NeptunId };
            Presentation Menedzsment = new Presentation() { PresentationName = "Menedzsment alapjai",  RoomNumber = BA210.RoomNumber, InstrctoreNeptunId = DrBujdosoLaszlo.NeptunId };
            Presentation AngolSzaknyelv = new Presentation() { PresentationName = "Angol Szaknyel A",  RoomNumber = BC3304.RoomNumber, InstrctoreNeptunId = GyorineKontorEva.NeptunId };

            modelBuilder.Entity<Instructor>().HasData(KovacsAndras, DrHolynkaPeter, DurczyLevente, SimonNagyGabriella, DrBujdosoLaszlo, GyorineKontorEva);
            modelBuilder.Entity<LectureHall>().HasData(BAF01, BA132, BA115, BA210, BC3304);
            modelBuilder.Entity<Presentation>().HasData(HFT, SZTF1, ARCHI1, VIR, Menedzsment, AngolSzaknyelv);


        }

    }
}
