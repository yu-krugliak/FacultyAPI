using AutoMapper;
using Db.IRepository;
using FacultyApi.API.V1.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace Api.Integration.Tests.Controllers
{
    public class StudentControllerTest
    {

        private readonly HttpClient _httpClient;
        private readonly Mock<IZipcanClient> _zipcanClient;
        private readonly HiTouchDbContext _dbContext;

        private readonly Mock<ILogger<StudentsController>> _logger;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IStudentsRepository> _studentsRepositoryMock;
        private readonly StudentsController _studentsController;




        public StudentControllerTest()
        {
            this._logger = new Mock<ILogger<StudentsController>>();
            this._studentsRepositoryMock = new Mock<IStudentsRepository>();

            this._studentsController = new StudentsController(_studentsRepositoryMock.Object, _logger.Object, _mapperMock.Object);
        }

        [Fact]
        public void GetAll_()
        {

        }
    }
}
