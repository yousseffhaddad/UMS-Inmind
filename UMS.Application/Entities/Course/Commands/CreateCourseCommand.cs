using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Course.Commands;

public class CreateCourseCommand:IRequest<string>
{
    public Domain.Models.Course course { get; set; }
    
}