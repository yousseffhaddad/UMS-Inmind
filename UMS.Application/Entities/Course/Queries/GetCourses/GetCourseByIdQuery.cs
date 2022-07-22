using MediatR;

namespace UMS.Application.Entities.Course.Queries.GetCourses;

public class GetCourseByIdQuery:IRequest<Domain.Models.Course>
{
    public long Id { get; set; }
    
}