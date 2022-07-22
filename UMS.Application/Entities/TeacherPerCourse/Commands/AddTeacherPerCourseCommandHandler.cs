using MediatR;
using UMS.Application.Abstraction;
using UMS.Application.Entities.Course.Commands;
using UMS.Persistence;

namespace UMS.Application.Entities.TeacherPerCourse.Commands;

public class AddTeacherPerCourseCommandHandler:IRequestHandler<AddTeacherPerCourseCommand,string>
{
    private readonly umsContext _dbContext;

    public AddTeacherPerCourseCommandHandler(umsContext context)
    {
        _dbContext = context;
    }
    public async Task<string> Handle(AddTeacherPerCourseCommand request, CancellationToken cancellationToken)
    {
        _dbContext.Add(request.TeacherPerCourse);
        _dbContext.Add(request.SessionTime);
        await _dbContext.SaveChangesAsync(cancellationToken);
        _dbContext.Add(new Domain.Models.TeacherPerCoursePerSessionTime()
        {
            TeacherPerCourseId = request.TeacherPerCourse.Id,
            SessionTimeId = request.SessionTime.Id
        });
        await _dbContext.SaveChangesAsync(cancellationToken);

        return "Added Successfully!";

    }
}