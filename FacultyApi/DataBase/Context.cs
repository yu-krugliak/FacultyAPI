using System;
using Microsoft.EntityFrameworkCore;

namespace FacultyApi.DataBase
{
    public sealed class Context : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<EducationType> EducationTypes { get; set; }


        public Context(DbContextOptions<Context> options) : base(options)
        { 
            //Database.EnsureDeleted();
            Database.EnsureCreated();

            //var group = new Group()
            //{
            //    Name = "IM420"
            //};

            //Groups?.Add(group);
            //SaveChanges();

            //var educationType = new EducationType()
            //{
            //    Name = "Очный"
            //};

            //EducationTypes?.Add(educationType);
            //SaveChanges();

            //var student = new Student()
            //{
            //    FirstName = "Владислав",
            //    SecondName = "Ильченко",
            //    MiddleName = "Алексеевич",
            //    PhoneNumber = "0995031137",
            //    YearEntry = new DateTime(2018, 08, 01),
            //    Expelled = false,
            //    EducationTypeId = 1,
            //    GroupId = 1
            //};

            //Students?.Add(student);
            //SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>().HasKey(s => s.EducationTypeId);
            //modelBuilder.Entity<Student>().HasKey(s => s.GroupId);

            //modelBuilder.Entity<Student>()
            //    .HasOne(s => s.EducationType)
            //    .WithMany(g => g.Students)
            //    .HasForeignKey(s => s.EducationTypeId);
        }
    }
}