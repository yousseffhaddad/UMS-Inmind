using AutoMapper;
using UMS.Domain.Models;
using UMS.DTO;

namespace UMS.Profiles;

public class StudentEnrollmentProfile:Profile
{
    public StudentEnrollmentProfile()
    {
        CreateMap<StudentEnrollDTO, ClassEnrollment>();
    }
}