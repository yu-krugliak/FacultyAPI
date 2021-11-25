using System;
using Db.Models.Basic;
using Db.Models.EducationTypes;
using Db.Models.Students;
using Microsoft.EntityFrameworkCore;

namespace Db.Models
{
    public class Context : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<UserService> Lessons { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<EducationType> EducationTypes { get; set; }


        public Context(DbContextOptions<Context> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
                entity.HasKey(student => student.StudentId);

                entity.Property(student => student.StudentId).ValueGeneratedOnAdd();
                entity.Property(student => student.SecondName);
                entity.Property(student => student.FirstName);
                entity.Property(student => student.MiddleName);

                //entity.Property(student => student.Name1);
                //entity.Property(student => student.Name1);
                //entity.Property(student => student.Name3);
                //entity.Property(student => student.Name4);


                entity.Property(student => student.YearEntry);
                entity.Property(student => student.PhoneNumber);
                entity.Property(student => student.Expelled);

                entity.HasOne(student => student.Group)
                    .WithMany(group => group.Students);

                entity.HasOne(student => student.EducationType)
                    .WithMany(education => education.Students)
                    ;

            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Groups");
                entity.HasKey(group => group.GroupId);

                entity.Property(group => group.GroupId).ValueGeneratedOnAdd();
                entity.Property(group => group.Name);
            });

            modelBuilder.Entity<EducationType>(entity =>
            {
                entity.ToTable("EducationTypes");
                entity.HasKey(education => education.EducationTypeId);

                entity.Property(education => education.EducationTypeId).ValueGeneratedOnAdd();
                entity.Property(education => education.Name);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subjects");
                entity.HasKey(subject => subject.SubjectId);

                entity.Property(subject => subject.SubjectId).ValueGeneratedOnAdd();
                entity.Property(subject => subject.Name);

                entity.HasOne(subject => subject.Lecturer)
                    .WithMany(lecturer => lecturer.Subjects);

                entity.HasMany(subject => subject.Lessons)
                    .WithOne(lesson => lesson.Subject)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.ToTable("Lecturers");
                entity.HasKey(lecturer => lecturer.LecturerId);

                entity.Property(lecturer => lecturer.LecturerId).ValueGeneratedOnAdd();
                entity.Property(lecturer => lecturer.SecondName);
                entity.Property(lecturer => lecturer.FirstName);
                entity.Property(lecturer => lecturer.MiddleName);
                entity.Property(lecturer => lecturer.Degree);
                entity.Property(lecturer => lecturer.Position);
                entity.Property(lecturer => lecturer.PhoneNumber);

                entity.HasMany(lecturer => lecturer.Subjects)
                    .WithOne(subject => subject.Lecturer)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UserService>(entity =>
            {
                entity.ToTable("Lessons");
                entity.HasKey(lesson => lesson.LessonId);

                entity.Property(lesson => lesson.LessonId).ValueGeneratedOnAdd();
                entity.Property(lesson => lesson.Semester);
                entity.Property(lesson => lesson.DayAndTime);
            });

            //var group = new Group()
            //{
            //    Name = "IM420"
            //};
            ////var group = new Group()
            ////{
            ////    Name = "IM420"
            ////};

            //Groups?.Add(group);
            //SaveChanges();
            ////Groups?.Add(group);
            ////SaveChanges();

            //var educationType = new EducationType()
            //{
            //    Name = "Очный"
            //};
            ////var educationType = new EducationType()
            ////{
            ////    Name = "Очный"
            ////};

            //EducationTypes?.Add(educationType);
            //SaveChanges();
            ////EducationTypes?.Add(educationType);
            ////SaveChanges();

            //var student = new Student()
            //{
            //    FirstName = "Владислав",
            //    SecondName = "Ильченко",
            //    MiddleName = "Алексеевич",
            //    PhoneNumber = "0995031137",
            //    YearEntry = new DateTime(2018, 08, 01),
            //    Expelled = false,
            //    EducationTypeId = null,
            //    GroupId = null
            //};
            ////var student = new Student()
            ////{
            ////    FirstName = "Владислав",
            ////    SecondName = "Ильченко",
            ////    MiddleName = "Алексеевич",
            ////    PhoneNumber = "0995031137",
            ////    YearEntry = new DateTime(2018, 08, 01),
            ////    Expelled = false,
            ////    EducationTypeId = 1,
            ////    GroupId = 1
            ////};

            //Students?.Add(student);
            //SaveChanges();
            ////Students?.Add(student);
            ////SaveChanges();
        }
    }
    
}