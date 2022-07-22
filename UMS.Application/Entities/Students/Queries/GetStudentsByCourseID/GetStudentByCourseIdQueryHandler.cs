using MediatR;
using UMS.Application.Abstraction;
using UMS.Application.Entities.Course.Queries.GetCourses;
using UMS.Domain.Models;
using UMS.Persistence;

namespace UMS.Application.Entities.Students.Queries.GetStudentsByCourseID;

public class GetStudentByCourseIdQueryHandler:IRequestHandler<GetStudentByCourseIdQuery,List<Domain.Models.User>>
{
    private readonly IRepository<Domain.Models.User> _repository;
    private readonly umsContext _dbContext;
    public GetStudentByCourseIdQueryHandler(IRepository<Domain.Models.User> repository,umsContext context)
    {
        _repository = repository;
        _dbContext = context;
    }
    public async Task<List<Domain.Models.User>> Handle(GetStudentByCourseIdQuery request, CancellationToken cancellationToken)
    {
        var students = (from ep in _dbContext.Courses
            join e in _dbContext.TeacherPerCourses on ep.Id equals e.CourseId
            join t in _dbContext.ClassEnrollments on e.Id equals t.ClassId
            join u in _dbContext.Users on t.StudentId equals u.Id
            where ep.Id == request.Id
            select u).ToList();
        
        return students;
        

    }
}