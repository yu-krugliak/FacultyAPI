using AutoMapper;
using Db.Models.Students;

namespace FacultyApi.Configuration
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            AllowNullCollections = true;

            CreateMap<CreateStudentModel, Student>()
                .ForMember(dest => dest.SecondName, obj => obj.MapFrom(src => src.FamilienName))
                .ForMember(dest => dest.FirstName, obj => obj.MapFrom(src => src.Name))
                .ForMember(dest => dest.MiddleName, obj => obj.MapFrom(src => src.MidName));

            CreateMap<UpdateStudentModel, Student>();
            CreateMap<Student, ReadStudentModel>();
        }
    }
}
