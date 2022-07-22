using MediatR;
using UMS.Application.Abstraction;
using UMS.Domain.Models;
using UMS.Persistence;

namespace UMS.Application.Entities.Course.Commands;

public class CreateCourseCommandHandler:IRequestHandler<CreateCourseCommand,string>
{
    private readonly IRepository<Domain.Models.Course> _repository;

    public CreateCourseCommandHandler(IRepository<Domain.Models.Course> repository)
    {
        _repository = repository;
    }
    public async Task<string> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        return await _repository.AddAsync(request.course);
        
    }
}