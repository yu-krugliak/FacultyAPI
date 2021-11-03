﻿// <auto-generated />
using System;
using FacultyApi.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DbMigrations.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20211103144645_testm2jj")]
    partial class testm2jj
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("FacultyApi.DataBase.EducationType", b =>
                {
                    b.Property<Guid>("EducationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("EducationTypeId");

                    b.ToTable("EducationTypes");
                });

            modelBuilder.Entity("FacultyApi.DataBase.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("FacultyApi.DataBase.Lecturer", b =>
                {
                    b.Property<Guid>("LecturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Degree")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .HasColumnType("text");

                    b.Property<string>("SecondName")
                        .HasColumnType("text");

                    b.HasKey("LecturerId");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("FacultyApi.DataBase.Lesson", b =>
                {
                    b.Property<Guid>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DayAndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("GroupId1")
                        .HasColumnType("uuid");

                    b.Property<int?>("LecturerId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("LecturerId1")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Semester")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("SubjectId1")
                        .HasColumnType("uuid");

                    b.HasKey("LessonId");

                    b.HasIndex("GroupId1");

                    b.HasIndex("LecturerId1");

                    b.HasIndex("SubjectId1");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("FacultyApi.DataBase.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("EducationTypeId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("EducationTypeId1")
                        .HasColumnType("uuid");

                    b.Property<bool>("Expelled")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("GroupId1")
                        .HasColumnType("uuid");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("SecondName")
                        .HasColumnType("text");

                    b.Property<DateTime>("YearEntry")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("StudentId");

                    b.HasIndex("EducationTypeId1");

                    b.HasIndex("GroupId1");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("FacultyApi.DataBase.Subject", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("LecturerId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("LecturerId1")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("SubjectId");

                    b.HasIndex("LecturerId1");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("FacultyApi.DataBase.Lesson", b =>
                {
                    b.HasOne("FacultyApi.DataBase.Group", "Group")
                        .WithMany("Lessons")
                        .HasForeignKey("GroupId1");

                    b.HasOne("FacultyApi.DataBase.Lecturer", "Lecturer")
                        .WithMany("Lessons")
                        .HasForeignKey("LecturerId1");

                    b.HasOne("FacultyApi.DataBase.Subject", "Subject")
                        .WithMany("Lessons")
                        .HasForeignKey("SubjectId1");

                    b.Navigation("Group");

                    b.Navigation("Lecturer");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("FacultyApi.DataBase.Student", b =>
                {
                    b.HasOne("FacultyApi.DataBase.EducationType", "EducationType")
                        .WithMany("Students")
                        .HasForeignKey("EducationTypeId1");

                    b.HasOne("FacultyApi.DataBase.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId1");

                    b.Navigation("EducationType");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("FacultyApi.DataBase.Subject", b =>
                {
                    b.HasOne("FacultyApi.DataBase.Lecturer", "Lecturer")
                        .WithMany("Subjects")
                        .HasForeignKey("LecturerId1");

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("FacultyApi.DataBase.EducationType", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("FacultyApi.DataBase.Group", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("FacultyApi.DataBase.Lecturer", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("FacultyApi.DataBase.Subject", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
