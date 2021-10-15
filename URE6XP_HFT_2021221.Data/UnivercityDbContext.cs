using Microsoft.EntityFrameworkCore;
using System;
using URE6XP_HFT_2021221.Models;


namespace URE6XP_HFT_2021221.Data
{
    public class UnivercityDbContext : DbContext
    {
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Presentation> Presentations { get; set; }
        public virtual DbSet<LectureHall> Students { get; set; }
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
            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasMany(instructor => instructor.Presentations)
                .WithOne(presentation => presentation.InstructorNeptunId)
                .HasForeignKey(presentation => presentation.InstructorNeptunId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Presentation>(entity =>
            {
                entity.HasOne(presentation => presentation.LectureHall)
                .WithMany(lectureHall => lectureHall.Presentations)
                .HasForeignKey(presentations => presentations.LectureHall)
                .OnDelete(DeleteBehavior.Restrict);
                
            });






        }

    }
}
