using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
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


        public IEnumerable<T> GetAll<T>(string entityName)
        {
            var request = new RestRequest($"{entityName}", Method.GET);
            LogRequest(request);

            var response = _client.Execute<IEnumerable<T>>(request);
            LogResponse(response);

            return response.Data;
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
            MessageBox.Show("Object added");
        }

        public void Update<T>(string entityName, T record)
        {
            var request = new RestRequest(entityName, Method.POST)
                .AddJsonBody(record);

            _client.Execute(request);
            MessageBox.Show("Object updated");
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