using MediatR;

namespace UMS.Application.Entities.StudentEnrollment.Commands;

public class EnrollStudentCommand:IRequest<string>
{
    public Domain.Models.ClassEnrollment EnrollStudent { get; set; }
    
}