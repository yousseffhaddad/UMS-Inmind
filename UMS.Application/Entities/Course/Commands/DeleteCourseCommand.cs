using MediatR;

namespace UMS.Application.Entities.Course.Commands;

public class DeleteCourseCommand:IRequest<string>
{
    public long Id { get; set; }
    
}