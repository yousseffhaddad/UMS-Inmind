using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application.Entities.Students.Queries.GetStudentsByCourseID;

namespace UMS.Controllers;
[ApiController]
[Route("[controller]")]
public class StudentController:ControllerBase
{
    private readonly IMediator _mediator;
    
    public StudentController(IMediator mediator)
    {
        _mediator = mediator;

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllStudentsPerCourse([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetStudentByCourseIdQuery
        {
            Id = id
        });
        
        return Ok(result);
    } 
    
}