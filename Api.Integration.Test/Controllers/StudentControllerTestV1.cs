using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Db.Models.Students;
using FacultyApi;
using System.Text.Json;
using Db.Models;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Integration.Test.Controllers
{
    public class StudentControllerTestV1 : IClassFixture<TestWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly Context _dbContext;

        private readonly Student _testStudent;

        public StudentControllerTestV1(TestWebApplicationFactory<Startup> _startup)
        {
            var scopeFactory = _startup.Services.GetService<IServiceScopeFactory>();
            _dbContext = scopeFactory.CreateScope().ServiceProvider.GetService<Context>();

            var studentEntry = _dbContext.Students.Add(new Student
            {
                FirstName = "TEST"
            });
            _dbContext.SaveChanges();

            studentEntry.State = EntityState.Detached;
            _testStudent = studentEntry.Entity;

            _httpClient = _startup.WithWebHostBuilder(builder =>
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton(_dbContext);
                })
                ).CreateClient();
        }


        [Fact]
        public async Task GetFiltered_PropertyFilterValues_ReturnOk(/*Guid? groupId, bool? expelled, string secondName*/)
        {
            // Arrange
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1/students/getfiltered");

            // Act
            var response = await _httpClient.SendAsync(httpRequest);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAsync_PropertyId_ReturnOk()
        {
            // Arrange
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1/students/get/{_testStudent.StudentId}");

            // Act
            var response = await _httpClient.SendAsync(httpRequest);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UpdateAsync_PropertyStudent_ReturnOk()
        {
            // Arrange
            var requestStudent = new UpdateStudentModel()
            {
                StudentId = _testStudent.StudentId,
                FirstName = "Yui",
                SecondName = "Weri",
                MiddleName = "loi",
                YearEntry = new DateTime(),
                Expelled = true
            };
            var jsonRequestStudent = JsonSerializer.Serialize(requestStudent);

            var httpRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"/api/v1/students/update", UriKind.Relative),
                Content = new StringContent(jsonRequestStudent, Encoding.Default, "application/json")
            };


            // Act
            var response = await _httpClient.SendAsync(httpRequest);
            var jsonResponseContent = await response.Content.ReadAsStringAsync();

            var responseContent = JsonSerializer.Deserialize<Student>(jsonResponseContent); 


            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            Assert.Equal(requestStudent.StudentId, responseContent.StudentId);
            Assert.Equal(requestStudent.FirstName, responseContent.FirstName);
            Assert.Equal(requestStudent.SecondName, responseContent.SecondName);
            Assert.Equal(requestStudent.MiddleName, responseContent.MiddleName);
            Assert.Equal(requestStudent.YearEntry, responseContent.YearEntry);
            Assert.Equal(requestStudent.Expelled, responseContent.Expelled);
        }
    }
}