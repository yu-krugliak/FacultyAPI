using System;
using System.Collections.Generic;
using System.Linq;
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

        private readonly Guid _studentId;

        public StudentControllerTestV1(TestWebApplicationFactory<Startup> _startup)
        {
            var buider = new DbContextOptionsBuilder<Context>();
            buider.UseInMemoryDatabase(Guid.NewGuid().ToString());
            
            _dbContext = new Context(buider.Options);
            _studentId = Guid.NewGuid();
            _dbContext.Students.Add(new Student
            {
                StudentId = _studentId,
                FirstName = "TEST"
            });
            _dbContext.SaveChanges();

            _httpClient = _startup.WithWebHostBuilder(builder =>
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton(_dbContext);
                })
                ).CreateClient();
        }


        [Fact]
        public async Task GetFiltered_NoFilterValues_ReturnListStudentsReturnOk(/*Guid? groupId, bool? expelled, string secondName*/)
        {
            // Arrange
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                FirstName = "First"
            });
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                FirstName = "Second"
            });
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                FirstName = "Third"
            });
            _dbContext.SaveChanges();

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1/students/getfiltered");

            // Act
            var response = await _httpClient.SendAsync(httpRequest);
            var jsonResponseContent = await response.Content.ReadAsStringAsync();
            var responseContent = JsonSerializer.Deserialize<List<Student>>(jsonResponseContent);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(_dbContext.Students.Count(), responseContent.Count);

            Assert.Equal(_dbContext.Students.First().StudentId, responseContent.First().StudentId);
            Assert.Equal(_dbContext.Students.First().FirstName, responseContent.First().FirstName);

            Assert.Equal(_dbContext.Students.Last().StudentId, responseContent.Last().StudentId);
            Assert.Equal(_dbContext.Students.Last().FirstName, responseContent.Last().FirstName);
        }

        [Theory]
        [InlineData("00ebf684-3797-473b-a503-a88c1c4cbb6d")]
        public async Task GetFiltered_GroupIdFilterValue_ReturnListStudentsFilteredByGroupIdReturnOk(Guid groupId)
        {
            // Arrange
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                FirstName = "First",
                GroupId = groupId
            });
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                FirstName = "Second",
            });
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                FirstName = "Third",
                GroupId = groupId
            });
            _dbContext.SaveChanges();
            var countStudents = _dbContext.Students.Count(st => st.GroupId == groupId);

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1/students/getfiltered?groupId={groupId}");

            // Act
            var response = await _httpClient.SendAsync(httpRequest);
            var jsonResponseContent = await response.Content.ReadAsStringAsync();
            var responseContent = JsonSerializer.Deserialize<List<Student>>(jsonResponseContent);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(countStudents, responseContent.Count);

            Assert.Equal(_dbContext.Students.First(st => st.GroupId == groupId).StudentId, responseContent.First().StudentId);
            Assert.Equal(_dbContext.Students.First(st => st.GroupId == groupId).FirstName, responseContent.First().FirstName);
        }

        [Theory]
        [InlineData("Second")]
        public async Task GetFiltered_SecondNameFilterValue_ReturnListStudentsFilteredBySecondNameReturnOk(string secondName)
        {
            // Arrange
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                SecondName = "First",
            });
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                SecondName = "Second",
            });
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                SecondName = "Third",
            });
            _dbContext.SaveChanges();
            var countStudents = _dbContext.Students.Count(st => st.SecondName == secondName);

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1/students/getfiltered?secondName={secondName}");

            // Act
            var response = await _httpClient.SendAsync(httpRequest);
            var jsonResponseContent = await response.Content.ReadAsStringAsync();
            var responseContent = JsonSerializer.Deserialize<List<Student>>(jsonResponseContent);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(countStudents, responseContent.Count);

            Assert.Equal(_dbContext.Students.First(st => st.SecondName == secondName).StudentId, responseContent.First().StudentId);
            Assert.Equal(_dbContext.Students.First(st => st.SecondName == secondName).FirstName, responseContent.First().FirstName);
        }

        [Theory]
        [InlineData(true)]
        public async Task GetFiltered_ExpelledFilterValue_ReturnListStudentsFilteredByExpelledReturnOk(bool expelled)
        {
            // Arrange
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                FirstName = "First",
                Expelled = expelled
            });
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                FirstName = "Second",
            });
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                FirstName = "Third",
                Expelled = expelled
            });
            _dbContext.SaveChanges();
            var countStudents = _dbContext.Students.Count(st => st.Expelled == expelled);

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1/students/getfiltered?expelled={expelled}");

            // Act
            var response = await _httpClient.SendAsync(httpRequest);
            var jsonResponseContent = await response.Content.ReadAsStringAsync();
            var responseContent = JsonSerializer.Deserialize<List<Student>>(jsonResponseContent);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(countStudents, responseContent.Count);

            Assert.Equal(_dbContext.Students.First(st => st.Expelled == expelled).StudentId, responseContent.First().StudentId);
            Assert.Equal(_dbContext.Students.First(st => st.Expelled == expelled).FirstName, responseContent.First().FirstName);
        }

        [Theory]
        [InlineData("00ebf684-3797-473b-a503-a88c1c4cbb6d", true, "Second")]
        [InlineData("00ebf684-3797-473b-a503-a88c1c4cbb6f", false, "First")]
        public async Task GetFiltered_AllFilterValue_ReturnListStudentsFilteredReturnOk(Guid groupId, bool expelled, string secondName)
        {
            // Arrange
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                SecondName = "First",
                GroupId = groupId,
                Expelled = expelled
            });
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                SecondName = "Second",
                GroupId = groupId,
                Expelled = expelled
            });
            _dbContext.Students.Add(new Student
            {
                StudentId = Guid.NewGuid(),
                SecondName = "Second",
                GroupId = groupId,
                Expelled = expelled
            });
            _dbContext.SaveChanges();

            var dbFilteredStudents = _dbContext.Students.Where(st =>
                st.SecondName == secondName
                && st.GroupId == groupId
                && st.Expelled == expelled);
            var countStudents = dbFilteredStudents.Count();

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1/students/getfiltered?groupId={groupId}&expelled={expelled}&secondName={secondName}");

            // Act
            var response = await _httpClient.SendAsync(httpRequest);
            var jsonResponseContent = await response.Content.ReadAsStringAsync();
            var responseContent = JsonSerializer.Deserialize<List<Student>>(jsonResponseContent);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(countStudents, responseContent.Count);

            Assert.Equal(dbFilteredStudents.First().StudentId, responseContent.First().StudentId);
            Assert.Equal(dbFilteredStudents.First().FirstName, responseContent.First().FirstName);
        }

        [Fact]
        public async Task GetAsync_ExsistedId_ReturnStudentReturnOk()
        {
            // Arrange
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1/students/get/{_studentId}");

            // Act
            var response = await _httpClient.SendAsync(httpRequest);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAsync_NotExsistedId_ReturnNoFound()
        {
            // Arrange
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1/students/get/{"00ebf684-3797-473b-a503-a88c1c4cbb6d"}");

            // Act
            var response = await _httpClient.SendAsync(httpRequest);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task UpdateAsync_StudentValidData_SaveDataInDBReturnOk()
        {
            // Arrange
            var requestStudent = new UpdateStudentModel()
            {
                StudentId = _studentId,
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