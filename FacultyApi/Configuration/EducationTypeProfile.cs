using AutoMapper;
using Db.Models.EducationTypes;

namespace FacultyApi.Configuration
{
    public class EducationTypeProfile : Profile
    {
        public EducationTypeProfile()
        {
            CreateMap<CreateEducationModel, EducationType>();
            CreateMap<UpdateEducationModel, EducationType>();
            CreateMap<EducationType, ReadEducationModel>();
        }
    }
}
