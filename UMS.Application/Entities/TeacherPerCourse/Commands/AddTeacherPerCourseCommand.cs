using MediatR;

namespace UMS.Application.Entities.TeacherPerCourse.Commands;

public class AddTeacherPerCourseCommand:IRequest<string>
{
    public Domain.Models.TeacherPerCourse TeacherPerCourse { get; set; }
    public Domain.Models.SessionTime SessionTime { get; set; }
    
}