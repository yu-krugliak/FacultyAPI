using System.Collections.Generic;
using System.Windows.Forms;
using FacultyApiClientWinForms.Client;
using FacultyApiClientWinForms.Models;
using Newtonsoft.Json;
using RestSharp;
using Serilog;

namespace FacultyApiClientWinForms.Extensions
{
    public static class FacultyClientStudentExtensions
    {
        public static IEnumerable<Student> GetAllStudents(this FacultyClient client)
        {
            return client.GetAll<Student>("students");
        }

        public static void AddStudent(this FacultyClient client, Student student)
        {
            client.Add("students", student);
        }

        public static void UpdateStudent(this FacultyClient client, Student student)
        {
            client.Update("students", student);
        }

        public static void DeleteStudent(this FacultyClient client, int id)
        {
            client.Delete("students", id);
        }
    }
}