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
                .HasForeignKey(presentations => presentations.LectureHall)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(presentation => presentation.Instructor)
                .WithMany(instructor => instructor.Presentations)
                .HasForeignKey(presentation => presentation.Instructor)
                .OnDelete(DeleteBehavior.Restrict);
                
            });

            Instructor KovacsAndras = new Instructor() { Name = "Kovács András", NeptunId = "DFVW5VD" };
            Instructor DrHolynkaPeter = new Instructor() { Name = "Dr.Holynka Péter", NeptunId = "553KJA" };
            Instructor DurczyLevente = new Instructor() { Name = "Durczy Lenevte", NeptunId = "DF666D" };
            Instructor SimonNagyGabriella = new Instructor() { Name = "Simon-Nagy Gabriella", NeptunId = "LADDEE" };
            Instructor DrBujdosoLaszlo = new Instructor() { Name = "Dr.Bujdosó László", NeptunId = "KKKVAN" };
            Instructor GyorineKontorEva = new Instructor() { Name = "Győriné Kontor Éva", NeptunId = "ANGOL1" };

            LectureHall BAF01 = new LectureHall() { RoomNumber = "BA.F.01"};
            LectureHall BA131 = new LectureHall() { RoomNumber = "BA.1.32.Audmax"};
            LectureHall BA115 = new LectureHall() { RoomNumber = "BA.1.15"};
            LectureHall BA210 = new LectureHall() { RoomNumber = "BA.2.10"};
            LectureHall BC3304 = new LectureHall() { RoomNumber = "BC.3.304"};


            Presentation HFT = new Presentation() { PresentationName = "HFT", LectureHall = BAF01, Instructor = KovacsAndras };
            Presentation SZTF1 = new Presentation() { PresentationName = "SZTF1", LectureHall = BA131, Instructor = KovacsAndras };
            Presentation ARCHI1 = new Presentation() { PresentationName = "Archi 1", LectureHall = BAF01, Instructor = DurczyLevente };
            Presentation VIR = new Presentation() { PresentationName = "VIR", LectureHall = BC3304, Instructor = DrHolynkaPeter };
            Presentation Menedzsment = new Presentation() { PresentationName = "Menedzsment alapjai", LectureHall = BA210, Instructor = DrBujdosoLaszlo };
            Presentation AngolSzaknyelv = new Presentation() { PresentationName = "Angol Szaknyel A", LectureHall = BC3304, Instructor = GyorineKontorEva };

            modelBuilder.Entity<Instructor>().HasData(KovacsAndras, DrHolynkaPeter, DurczyLevente, SimonNagyGabriella, DrBujdosoLaszlo, GyorineKontorEva);
            modelBuilder.Entity<LectureHall>().HasData(BAF01, BA131, BA115, BA210, BC3304);
            modelBuilder.Entity<Presentation>().HasData(HFT, SZTF1, ARCHI1, VIR, Menedzsment, AngolSzaknyelv);


        }

    }
}
