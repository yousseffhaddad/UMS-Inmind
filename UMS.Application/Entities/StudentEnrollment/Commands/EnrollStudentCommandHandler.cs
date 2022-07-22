using MediatR;
using UMS.Application.Abstraction;
using UMS.Application.Entities.Course.Commands;
using UMS.Domain.Models;
using UMS.Infrastructure.Abstraction.EmailServiceAbstraction;
using UMS.Persistence;

namespace UMS.Application.Entities.StudentEnrollment.Commands;

public class EnrollStudentCommandHandler : IRequestHandler<EnrollStudentCommand, string>
{
    private readonly IRepository<Domain.Models.ClassEnrollment> _repository;
    private readonly umsContext _dbContext;
    IEmailService _emailService ;
    
    public EnrollStudentCommandHandler(IRepository<Domain.Models.ClassEnrollment> repository,umsContext context,IEmailService emailService)
    {
        _repository = repository;
        _dbContext = context;
        _emailService = emailService;
    }
    public async Task<string> Handle(EnrollStudentCommand request, CancellationToken cancellationToken)
    {
        var course = (from ep in _dbContext.ClassEnrollments
                join e in _dbContext.TeacherPerCourses on ep.ClassId equals e.Id
                join t in _dbContext.Courses on e.CourseId equals t.Id
                where ep.ClassId == request.EnrollStudent.ClassId
                select new
                {
                    courseId = t.Id,
                    courseName=t.Name,
                    maxStudentNum = t.MaxStudentsNumber,
                    dateRange = t.EnrolmentDateRange
                }).FirstOrDefault();
        
        var user = (from u in _dbContext.Users
            where u.Id == request.EnrollStudent.StudentId
            select new
            {
                studentEmail = u.Email.ToString()
            }).FirstOrDefault();

        var maxStudNumberByCourse = _dbContext.ClassEnrollments.Count(t => t.ClassId == request.EnrollStudent.ClassId);
        DateOnly? startDate = course?.dateRange?.LowerBound;
        DateOnly? endDate = course?.dateRange?.UpperBound;
        
        if (startDate > DateOnly.FromDateTime(DateTime.Now) || DateOnly.FromDateTime(DateTime.Now)  > endDate)
        {
            return "You cant Enroll At this time";

        }
        if (maxStudNumberByCourse > course?.maxStudentNum)
        {
            return "Class is Full";
        }
        
        var response= await _repository.AddAsync(request.EnrollStudent);
        _emailService.SendEmail( user?.studentEmail ,user?.studentEmail, "Enrollment Successful","you have been enrolled successfully to the course"+course.courseName);
        return response;


    }
}