using System.Collections.Generic;
using System.Windows.Forms;
using FacultyApiClientWinForms.Client;
using FacultyApiClientWinForms.Models;
using RestSharp;

namespace FacultyApiClientWinForms.Extensions
{
    public static class FacultyClientSubjectExtensions
    {
        public static IEnumerable<Subject> GetAllSubjects(this FacultyClient client) =>
            client.GetAll<Subject>("subjects");

    }
}