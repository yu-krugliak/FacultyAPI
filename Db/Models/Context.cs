using System;
using Microsoft.EntityFrameworkCore;

namespace FacultyApi.DataBase
{
    public class Context : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
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

                entity.Property(student => student.Name);

                entity.Property(student => student.MiddleName);
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

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lessons");
                entity.HasKey(lesson => lesson.LessonId);

                entity.Property(lesson => lesson.LessonId).ValueGeneratedOnAdd();
                entity.Property(lesson => lesson.Semester);
                entity.Property(lesson => lesson.DayAndTime);
            });
        }
    }
}