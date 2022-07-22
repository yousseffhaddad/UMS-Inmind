using MediatR;
using UMS.Application.Abstraction;

namespace UMS.Application.Entities.Course.Commands;

public class UpdateCourseCommandHandler:IRequestHandler<UpdateCourseCommand,string>
{
    private readonly IRepository<Domain.Models.Course> _repository;

    public UpdateCourseCommandHandler(IRepository<Domain.Models.Course> repository)
    {
        _repository = repository;
    }
    public async Task<string> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        return await _repository.UpdateAsync(request.course);
        
    }
}