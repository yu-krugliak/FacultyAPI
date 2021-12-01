using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Db.Models.Students;
using FacultyApi;
using System.Text.Json;
using Db.Models;
using Db.Models.Basic;
using Db.Models.EducationTypes;
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

        private readonly Guid _studentId;

        public StudentControllerTestV2(TestWebApplicationFactory<Startup> _startup)
        {
            var buider = new DbContextOptionsBuilder<Context>();
            buider.UseInMemoryDatabase(Guid.NewGuid().ToString());

            _dbContext = new Context(buider.Options);
            _studentId = Guid.NewGuid();
            var entityEntry = _dbContext.Students.Add(new Student
            {
                StudentId = _studentId,
                FirstName = "TEST"
            });
            _dbContext.SaveChanges();
            entityEntry.State = EntityState.Detached;


            _httpClient = _startup.WithWebHostBuilder(builder =>
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton(_dbContext);
                })
            ).CreateClient();
        }


        [Fact]
        public async Task AddAsync_StudentValidData_AddDataToDbReturnOk()
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
        public async Task AddAsync_StudentInvalidData_AddDataToDbReturnOk()
        {
            // Arrange
            var requestStudent = new CreateStudentModel()
            {
                Name = "World",
                GroupId = Guid.Empty
                
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

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task AddAsync_EmptyContent_ReturnBadRequest()
        {
            // Arrange
            var httpRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"/api/v2/students/add", UriKind.Relative),
                Content = new StringContent(string.Empty, Encoding.UTF8, "application/json")
            };


            // Act
            var response = await _httpClient.SendAsync(httpRequest);
            var jsonResponseContent = await response.Content.ReadAsStringAsync();

            var responseContent = JsonSerializer.Deserialize<Student>(jsonResponseContent);


            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }


        [Fact]
        public async Task DeleteAsync_ExistedId_DeleteInDbReturnOk()
        {
            // Arrange
            var httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"/api/v2/students/delete/{_studentId}");

            // Act
            var response = await _httpClient.SendAsync(httpRequest);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task DeleteAsync_NotExistedId_ReturnNotFoundk()
        {

            // Arrange
            var httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"/api/v2/students/delete/{"00ebf684-3797-473b-a503-a88c1c4cbb6d"}");

            // Act
            var response = await _httpClient.SendAsync(httpRequest);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}