using AutoMapper;
using NpgsqlTypes;
using UMS.Domain.Models;
using UMS.DTO;

namespace UMS.Profiles;

public class CreateCourseProfile : Profile
{
    public CreateCourseProfile()
    {
        CreateMap<CreateCourse, Course>()
            .ForPath(course => course.EnrolmentDateRange,
                options => options.MapFrom(createCourse => new NpgsqlRange<DateOnly>(DateOnly.FromDateTime(createCourse.StartTime), DateOnly.FromDateTime(createCourse.EndTime))));
    }
}