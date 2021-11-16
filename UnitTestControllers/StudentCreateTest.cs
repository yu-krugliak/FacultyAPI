using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
//using Db.IRepository;


namespace UnitTestControllers
{
    //[TestClass]
    //public class StudentCreateTest
    //{
    //    [TestMethod]
    //    public void TestMethod1()
    //    {
    //    }

    //    private readonly Mock<>
    //    private readonly Mock<IStudentsRepository> _studentsRepository;
    //    private readonly ILogger<StudentsController> _logger;
    //    private readonly IMapper _mapper;


    //    public StudentCreateTest(IStudentsRepository studentsRepository, ILogger<StudentsController> logger, IMapper mapper)
    //    {
    //        _studentsRepository = studentsRepository;
    //        _logger = logger;
    //        _mapper = mapper;
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> AddAsync([FromBody] CreateStudentModel student, CancellationToken cancellationToken = default)
    //    {
    //        _logger.LogInformation($"StudentPut:\n{JsonConvert.SerializeObject(student)}");

    //        try
    //        {
    //            var newStudent = _mapper.Map<Student>(student);
    //            await _studentsRepository.AddAsync(newStudent, cancellationToken);

    //            return Ok(student);
    //        }
    //        catch
    //        {
    //            return BadRequest();
    //        }
    //    }
    //}
}
