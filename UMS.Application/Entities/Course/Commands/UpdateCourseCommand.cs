using MediatR;

namespace UMS.Application.Entities.Course.Commands;

public class UpdateCourseCommand:IRequest<string>
{
    public Domain.Models.Course course { get; set; }
    
}