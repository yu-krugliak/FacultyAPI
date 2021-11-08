using AutoMapper;
using FacultyApi.DataBase;

namespace FacultyApi.Configuration
{
    public class EducationTypeProfile : Profile
    {
        public EducationTypeProfile()
        {
            CreateMap<CreateEducationModel, EducationType>();
            CreateMap<UpdateEducationModel, EducationType>();
            CreateMap<EducationType, ReadEducationModel>();
            CreateMap<EducationType, DeleteEducationModel>();

        }
    }
}
