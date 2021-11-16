using AutoMapper;
using Db.IRepository;
using Db.Models.Students;
using FacultyApi.API.V2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using Xunit;
using FluentAssertions;

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
            _studentsController = new StudentsController(_studentsRepositoryMock.Object, _logger.Object, _mapperMock.Object);

        }

        [Fact]
        public async void WhenCantMapShouldThrowException_BadRequestResult()
        {
            //Arrange
            var ex = new Exception("Message_error");
            _mapperMock.Setup(maper => maper.Map<Student>(It.IsAny<CreateStudentModel>()))
               .Throws(ex);//Returns(new Student());

            var student = new CreateStudentModel()
            {
                FamilienName = "www"
            };

            //Act
            var result = await _studentsController.AddAsync(student, _cancellationToken);

            //Assert
            //Assert.AreEqual("request can not be null", response.Message);
            //Assert.Equal(_logger.Object, ex);
            //result.Should().BeOfType<BadRequestObjectResult>();
            //Assert.Equal(ex.Message, _logger.Object.ToString());

            Assert.IsType<BadRequestObjectResult>(result);
            //_logger.Object

            this._logger.VerifyNoOtherCalls();
            this._mapperMock.VerifyNoOtherCalls();
            this._studentsRepositoryMock.VerifyNoOtherCalls();
        }


        [Fact]
        public async void WhenCantAddAsyncShouldThrowException_BadRequestResult()
        {
            //Arrange
            var ex = new Exception("Message_error");
            _mapperMock.Setup(maper => maper.Map<Student>(It.IsAny<CreateStudentModel>()))
               .Throws(ex);//Returns(new Student());

            var student = new CreateStudentModel()
            {
                FamilienName = "www"
            };

            //Act
            var result = await _studentsController.AddAsync(student, _cancellationToken);

            //Assert
            //Assert.AreEqual("request can not be null", response.Message);
            //Assert.Equal(_logger.Object, ex);
            //result.Should().BeOfType<BadRequestObjectResult>();
            //Assert.Equal(ex.Message, _logger.Object.ToString());

            Assert.IsType<BadRequestObjectResult>(result);
            //_logger.Object

            this._logger.VerifyNoOtherCalls();
            this._mapperMock.VerifyNoOtherCalls();
            this._studentsRepositoryMock.VerifyNoOtherCalls();
        }


        [Fact]
        public async void CreateStudentSuccessful_OkResult()
        {
            //Arrange
            //
            var student = new CreateStudentModel()
            {
                FamilienName = "www"
            };

            _mapperMock.Setup(maper => maper.Map<Student>(It.IsAny<CreateStudentModel>()))
               .Returns(new Student());

            
            //Act
            var result = await _studentsController.AddAsync(student, _cancellationToken);

            //Assert
            //Assert.AreEqual("request can not be null", response.Message);
            //Assert.Equal(_logger.Object, ex);
            //result.Should().BeOfType<BadRequestObjectResult>();
            //Assert.Equal(ex.Message, _logger.Object.ToString());

            Assert.IsType<OkObjectResult>(result);
            //_logger.Object
            this._mapperMock.Verify(mapper => mapper.Map<Student>(It.IsAny<CreateStudentModel>()), Times.Exactly(1));

            this._logger.VerifyNoOtherCalls();
            this._mapperMock.VerifyNoOtherCalls();
            //this._studentsRepositoryMock.VerifyNoOtherCalls();
        }

    }
}

