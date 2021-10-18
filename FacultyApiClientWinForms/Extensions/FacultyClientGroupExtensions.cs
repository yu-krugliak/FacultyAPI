using System.Collections.Generic;
using System.Windows.Forms;
using FacultyApiClientWinForms.Client;
using FacultyApiClientWinForms.Models;
using RestSharp;

namespace FacultyApiClientWinForms.Extensions
{
    public static class FacultyClientGroupExtensions
    {
        public static IEnumerable<Group> GetAllGroups(this FacultyClient client)
        {
            return client.GetAll<Group>("groups");
        }

        public static void AddGroup(this FacultyClient client, Group group)
        {
            client.Add("groups", group);
        }

        public static void UpdateGroup(this FacultyClient client, Group group)
        {
            client.Update("groups", group);
        }

        public static void DeleteGroup(this FacultyClient client, int id)
        {
            client.Delete("groups", id);
        }
    }
}