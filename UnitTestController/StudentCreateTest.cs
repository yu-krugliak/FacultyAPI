using AutoMapper;
using Db.IRepository;
using Db.Models.Students;
using FacultyApi.API.V2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Reflection;
using System.Threading;
using Xunit;
using FluentAssertions;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace UnitTestController
{
    public class StudentCreateTest
    {

        private readonly Mock<IStudentsRepository> _studentsRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        private readonly CancellationToken _cancellationToken;
        private readonly StudentsController _studentsController;
        private readonly Mock<ILogger<StudentsController>> _logger;


        public StudentCreateTest()
        {
            this._studentsRepositoryMock = new Mock<IStudentsRepository>();
            _mapperMock = new Mock<IMapper>();

            _cancellationToken = new CancellationTokenSource().Token;
            _logger = new Mock<ILogger<StudentsController>>();
            this._logger.Setup(logger => logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true)
                .Callback(() => this._logger.Verify(logger => logger.IsEnabled(It.IsAny<LogLevel>())));

            _studentsController = new StudentsController(_studentsRepositoryMock.Object, _logger.Object, _mapperMock.Object);

        }

        [Fact]
        public async void WhenCantMapShouldThrowException_BadRequestResult()
        {
            //Arrange
            var ex = new Exception("Message_error");
            _mapperMock.Setup(mapper => mapper.Map<Student>(It.IsAny<CreateStudentModel>()))
               .Throws(ex);

            var student = new CreateStudentModel()
            {
                FamilienName = "www"
            };

            //Act
            var result = await _studentsController.AddAsync(student, _cancellationToken);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(result);

            var objectResult = (BadRequestObjectResult)result;
            var exception = (Exception)objectResult.Value;

            Assert.Equal(ex.Message, exception.Message);

            this._mapperMock.Verify(mapper => mapper.Map<Student>(It.IsAny<CreateStudentModel>()), Times.Exactly(1));
            this._studentsRepositoryMock.Verify(s => s.AddAsync(It.IsAny<Student>(), this._cancellationToken), Times.Exactly(0));

            this._mapperMock.VerifyNoOtherCalls();
            this._studentsRepositoryMock.VerifyNoOtherCalls();
        }


        [Fact]
        public async void WhenCantAddAsyncShouldThrowException_BadRequestResult()
        {
            //Arrange
            var ex = new Exception("Message_error");
            _studentsRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Student>(), It.IsAny<CancellationToken>()))
                .Throws(ex);

   
            var student = new CreateStudentModel()
            {
                FamilienName = "www"
            };


            //Act
            var result = await _studentsController.AddAsync(student, _cancellationToken);


            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(result);

            var objectResult = (BadRequestObjectResult)result;
            var exception = (Exception)objectResult.Value;

            Assert.Equal(ex.Message, exception.Message);

            var str = $"StudentPut:\n{JsonConvert.SerializeObject(student)}";


            this._mapperMock.Verify(m => m.Map<Student>(student), Times.Once);
            this._studentsRepositoryMock.Verify(s => s.AddAsync(It.IsAny<Student>(), this._cancellationToken), Times.Once);


            _logger.Verify(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Once);
            _logger.Verify(x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    ex,
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);


            this._logger.VerifyNoOtherCalls();
            this._mapperMock.VerifyNoOtherCalls();
            this._studentsRepositoryMock.VerifyNoOtherCalls();
        }


        [Fact]
        public async void CreateStudentSuccessful_OkResult()
        {
            //Arrange
            var student = new CreateStudentModel()
            {
                FamilienName = "www"
            };

            _mapperMock.Setup(maper => maper.Map<Student>(It.IsAny<CreateStudentModel>()))
               .Returns(new Student());

            
            //Act
            var result = await _studentsController.AddAsync(student, _cancellationToken);

            //Assert
            Assert.IsType<OkObjectResult>(result);

            this._mapperMock.Verify(mapper => mapper.Map<Student>(It.IsAny<CreateStudentModel>()), Times.Exactly(1));
            this._studentsRepositoryMock.Verify(s => s.AddAsync(It.IsAny<Student>(), this._cancellationToken), Times.Once);

            _logger.Verify(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Once);

            this._mapperMock.VerifyNoOtherCalls();
            this._studentsRepositoryMock.VerifyNoOtherCalls();
        }

    }
}

