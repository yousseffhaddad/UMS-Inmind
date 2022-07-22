using AutoMapper;
using UMS.Domain.Models;
using UMS.DTO;

namespace UMS.Profiles;

public class SessionTimeProfile:Profile
{
    public SessionTimeProfile()
    {
        CreateMap<TeacherPerCourseDTO, SessionTime>();
    }
}