using System;
using System.Net.Http;
using System.Threading.Tasks;
using Db.Models.Students;
using FacultyApi;
using System.Text.Json;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Integration.Test.Controllers
{
    public class StudentControllerTest : IClassFixture<TestWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly DbContext _dbContext;

        public StudentControllerTest(TestWebApplicationFactory<Startup> _startup)
        {
            var scopeFactory = _startup.Services.GetService<IServiceScopeFactory>();
            _dbContext = scopeFactory.CreateScope().ServiceProvider.GetService<DbContext>();

            var dbOptions = new DbContextOptionsBuilder<DbContext>().UseInMemoryDatabase($"DB: {Guid.NewGuid()}").Options;
            var appContex = new DbContext(dbOptions);
            //appContex. .AddRange(_usersList);
            appContex.SaveChanges();

            _httpClient = _startup.WithWebHostBuilder(builder =>
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<DbContext>(_dbContext);
                })
                ).CreateClient();
        }


        //[Fact]
        //public async Task GetAll_SuccessInvocation_ReturnOk()
        //{
        //    var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1/EducationTypes/getall");
        //    var response = await _httpClient.SendAsync(httpRequest);

        //}

        [Theory]
        [InlineData(null, null, null)]
        public async Task GetFiltered_SuccessInvocation_ReturnOk(Guid? groupId, bool? expelled, string secondName)
        {
            // Arrange
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1/students/getfiltered");

            // Act
            var response = await _httpClient.SendAsync(httpRequest);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData (null)]
        public async Task GetAsync_SuccessInvocation_ReturnOk(Guid? id)
        {
            // Arrange
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1/students/get");

            // Act
            var response = await _httpClient.SendAsync(httpRequest);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UpdateAsync_SuccessInvocation_ReturnOk()
        {
            // Arrange
            var requestStudent = new UpdateStudentModel()
            {
                StudentId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
                FirstName = "Yui",
                SecondName = "Weri",
                MiddleName = "loi",
                YearEntry = new DateTime(),
                Expelled = true
            };

            var jsonRequestStudent = JsonSerializer.Serialize<UpdateStudentModel>(requestStudent);
            var httpRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"/api/v1/students/update"),
                Content = new StringContent(jsonRequestStudent)
            };
            
            // Act
            var response = await _httpClient.SendAsync(httpRequest);
            var jsonResponseContent = await response.Content.ReadAsStringAsync();

            var responseContent = JsonSerializer.Deserialize<Student>(jsonResponseContent);

            // Assert
            Assert.Equal(responseContent.StudentId, requestStudent.StudentId);
            Assert.Equal(responseContent.FirstName, requestStudent.FirstName);
            Assert.Equal(responseContent.SecondName, requestStudent.SecondName);
            Assert.Equal(responseContent.MiddleName, requestStudent.MiddleName);
            Assert.Equal(responseContent.YearEntry, requestStudent.YearEntry);
            Assert.Equal(responseContent.Expelled, requestStudent.Expelled);

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

    }
}