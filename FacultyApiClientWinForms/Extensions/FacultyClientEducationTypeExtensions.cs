using System.Collections.Generic;
using System.Windows.Forms;
using FacultyApiClientWinForms.Client;
using FacultyApiClientWinForms.Models;
using RestSharp;

namespace FacultyApiClientWinForms.Extensions
{
    public static class FacultyClientEducationTypeExtensions
    {
        public static IEnumerable<EducationType> GetAllEducations(this FacultyClient client)
        {
            return client.GetAll<EducationType>("educationTypes");
        }

        public static void AddEducation(this FacultyClient client, EducationType educationTypes)
        {
            client.Add("educationTypes", educationTypes);
        }

        public static void UpdateEducation(this FacultyClient client, EducationType educationTypes)
        {
            client.Update("educationTypes", educationTypes);
        }

        public static void DeleteEducation(this FacultyClient client, int id)
        {
            client.Delete("educationTypes", id);
        }
    }
}