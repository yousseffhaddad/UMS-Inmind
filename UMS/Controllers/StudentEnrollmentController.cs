using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application.Entities.StudentEnrollment.Commands;
using UMS.Domain.Models;
using UMS.DTO;

namespace UMS.Controllers;

[ApiController]
[Route("[controller]")]

public class StudentEnrollmentController:ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public StudentEnrollmentController(IMediator mediator,IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpPost("enrollment")]
    public async Task<IActionResult> Add([FromBody] StudentEnrollDTO e)
    {
        //TODO: Use AutoMapper for mappings
        ClassEnrollment enrollment = _mapper.Map<ClassEnrollment>(e);
        
        var result = await _mediator.Send(new EnrollStudentCommand()
            {
                EnrollStudent = enrollment
            });

        return Ok(result);
            
    }

    
}