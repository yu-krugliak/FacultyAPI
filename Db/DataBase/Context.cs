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
            //Database.EnsureCreated();

            //Groups.Add(new Group()
            //{
            //    Name = "IM420"
            //});
            //Groups.Add(new Group()
            //{
            //    Name = "К-27"
            //});
            //Groups.Add(new Group()
            //{
            //    Name = "К-19"
            //});
            //Groups.Add(new Group()
            //{
            //    Name = "МИ-3"
            //});
            //Groups.Add(new Group()
            //{
            //    Name = "ИС-12мп"
            //});


            //EducationTypes.Add(new EducationType()
            //{
            //    Name = "Дистанционный"
            //});
            //EducationTypes.Add(new EducationType()
            //{
            //    Name = "Очный"
            //});
            //EducationTypes.Add(new EducationType()
            //{
            //    Name = "Заочный"
            //});
            //EducationTypes.Add(new EducationType()
            //{
            //    Name = "Самообучение"
            //});

            //var student = new Student()
            //{
            //    FirstName = "Мая",
            //    SecondName = "Сперкач",
            //    MiddleName = "Олеговна",
            //    PhoneNumber = "0995031137",
            //    YearEntry = new DateTime(2018, 08, 01),
            //    Expelled = false,
            //    EducationTypeId = 1,
            //    GroupId = 1
            //};

            //Lecturers.Add(new Lecturer()
            //{
                
            //    Name = "Самообучение"
            //});

            //Students.Add(student);
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