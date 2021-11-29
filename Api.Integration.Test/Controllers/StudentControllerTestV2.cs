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
    public class StudentControllerTestV2 : IClassFixture<TestWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly Context _dbContext;

        private readonly Student _testStudent;

        public StudentControllerTestV2(TestWebApplicationFactory<Startup> _startup)
        {
            var scopeFactory = _startup.Services.GetService<IServiceScopeFactory>();
            _dbContext = scopeFactory.CreateScope().ServiceProvider.GetService<Context>();

            var studentEntry = _dbContext.Students.Add(new Student
            {
                FirstName = "Yui",
                SecondName = "Weri",
                MiddleName = "loi",
                YearEntry = new DateTime(),
                Expelled = true
            });
            _dbContext.SaveChanges();

            studentEntry.State = EntityState.Detached;
            _testStudent = studentEntry.Entity;

            _httpClient = _startup.WithWebHostBuilder(builder =>
                builder.ConfigureTestServices(services => { services.AddSingleton(_dbContext); })
            ).CreateClient();
        }


        [Fact]
        public async Task AddAsync_PropertyStudent_ReturnOk()
        {
            // Arrange
            var requestStudent = new CreateStudentModel()
            {
                FamilienName = "HI",
                Name = "World",
                MidName = "Kotikov",
                YearEntry = new DateTime(),
                Expelled = true
            };
            var jsonRequestStudent = JsonSerializer.Serialize(requestStudent);

            var httpRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"/api/v2/students/add", UriKind.Relative),
                Content = new StringContent(jsonRequestStudent, Encoding.UTF8, "application/json")
            };
            

            // Act
            var response = await _httpClient.SendAsync(httpRequest);
            var jsonResponseContent = await response.Content.ReadAsStringAsync();

            var responseContent = JsonSerializer.Deserialize<Student>(jsonResponseContent); 


            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            Assert.Equal(requestStudent.FamilienName, responseContent.SecondName);
            Assert.Equal(requestStudent.Name, responseContent.FirstName);
            Assert.Equal(requestStudent.MidName, responseContent.MiddleName);
            Assert.Equal(requestStudent.YearEntry, responseContent.YearEntry);
            Assert.Equal(requestStudent.Expelled, responseContent.Expelled);
        }
        
        
        [Fact]
        public async Task DeleteAsync_PropertyId_ReturnOk()
        {
            // Arrange
            var httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"/api/v2/students/delete/{_testStudent.StudentId}");

            // Act
            var response = await _httpClient.SendAsync(httpRequest);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

    }
}