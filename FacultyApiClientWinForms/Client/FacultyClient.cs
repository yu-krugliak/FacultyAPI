using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using FacultyApiClientWinForms.Models;
using Newtonsoft.Json;
using RestSharp;
using Serilog;

namespace FacultyApiClientWinForms.Client
{
    public class FacultyClient
    {

        private static FacultyClient _instance;
        private readonly IRestClient _client;

        public FacultyClient()
        {
            var baseUri = File.ReadAllText("app.config");
            _client = new RestClient(baseUri);
        }


        public static FacultyClient Instance
        {
            get
            {
                _instance ??= new FacultyClient();
                return _instance;
            }
        }

        public IEnumerable<T> GetAll<T>(RestRequest request)
        {
            LogRequest(request);

            var response = _client.Execute<IEnumerable<T>>(request);
            LogResponse(response);

            return response.Data;
        }

        public IEnumerable<T> GetAll<T>(string entityName)
        {
            var request = new RestRequest($"{entityName}", Method.GET);
            return GetAll<T>(request);
        }

        public IEnumerable<Student> GetAllStudents(string secondName = null, int? groupId = null, bool? expelled = null)
        {
            var request = new RestRequest("students", Method.GET);
            request.AddQueryParameter("secondname", secondName);
            request.AddQueryParameter("groupid", groupId?.ToString());
            request.AddQueryParameter("expelled", expelled?.ToString());

            return GetAll<Student>(request);
        }

        public IEnumerable<Lecturer> GetAllLecturers(string secondName = null, string degree = null, int? subjectId = null)
        {
            var request = new RestRequest("lecturers", Method.GET);
            request.AddQueryParameter("secondname", secondName);
            request.AddQueryParameter("degree", degree);
            request.AddQueryParameter("subjectid", subjectId?.ToString());

            return GetAll<Lecturer>(request);
        }

        public IEnumerable<Lesson> GetAllLessons(int? groupId = null)
        {
            var request = new RestRequest("lessons", Method.GET);
            request.AddQueryParameter("groupid", groupId?.ToString());

            return GetAll<Lesson>(request);
        }
        
        private void LogRequest(IRestRequest request, object body = null)
        {
            var requestToLog = new
            {
                resource = request.Resource,
                method = request.Method.ToString(),
                uri = _client.BuildUri(request),
                body
            };

            Log.Debug($"REQUEST:\n{JsonConvert.SerializeObject(requestToLog, Formatting.Indented)}");
        }

        private void LogResponse<T>(IRestResponse<T> response)
        {
            var responseToLog = new
            {
                statusCode = response.StatusCode,
                content = response.Content,
                responseUri = response.ResponseUri,
                errorMessage = response.ErrorMessage,
                body = response.Data
            };

            Log.Debug($"RESPONSE:\n{JsonConvert.SerializeObject(responseToLog, Formatting.Indented)}");
        }

        public void Add<T>(string entityName, T record)
        {
            var request = new RestRequest($"{entityName}", Method.PUT)
                .AddJsonBody(record);

            _client.Execute(request);
            //MessageBox.Show("Object added");
        }

        public void Update<T>(string entityName, T record)
        {
            var request = new RestRequest(entityName, Method.POST)
                .AddJsonBody(record);

            _client.Execute(request);
            //MessageBox.Show("Object updated");
        }

        public void Delete(string entityName, int id)
        {
            var request = new RestRequest("{entityName}/{id}", Method.DELETE)
                .AddUrlSegment("id", id)
                .AddUrlSegment("entityName", entityName);

            _client.Execute(request);
        }
    }
}