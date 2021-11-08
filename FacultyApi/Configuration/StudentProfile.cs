using AutoMapper;
using FacultyApi.DataBase;

namespace FacultyApi.Configuration
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            AllowNullCollections = true;
            CreateMap<CreateStudentModel, Student>();
            CreateMap<UpdateStudentModel, Student>();
            CreateMap<Student, ReadStudentModel>();
            CreateMap<Student, DeleteStudentModel>();

        }
    }
}
