using AutoMapper;
using UMS.Domain.Models;
using UMS.DTO;

namespace UMS.Profiles;

public class TeacherPerCourseProfile:Profile
{
    public TeacherPerCourseProfile()
    {
        CreateMap<TeacherPerCourseDTO, TeacherPerCourse>();
    }
}