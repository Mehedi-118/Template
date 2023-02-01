using AutoMapper;
using DTO;
using Model;

namespace Template.AutoMapper
{
    public class ModelDTOMapper:Profile
    {
        public ModelDTOMapper()
        {
            CreateMap<StudentInfoDTO, StudentInfo>().ReverseMap();
            CreateMap<CourseDTO, Course>().ReverseMap();
            CreateMap<DepartmentDTO, Department>().ReverseMap();
            CreateMap<GenericLookupDTO,GenericLookup>().ReverseMap();
            CreateMap<GenericLookupTypeDTO, GenericLookupType>().ReverseMap();
            CreateMap<StudentCoursesDTO, StudentCourses>().ReverseMap();
        }
    }
}
