using MediatR;
using UMS.Application.Abstraction;

namespace UMS.Application.Entities.Course.Commands;

public class DeleteCourseCommandHandler:IRequestHandler<DeleteCourseCommand,string>
{
    private readonly IRepository<Domain.Models.Course> _repository;

    public DeleteCourseCommandHandler(IRepository<Domain.Models.Course> repository)
    {
        _repository = repository;
    }
    public async Task<string> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);

    }
}