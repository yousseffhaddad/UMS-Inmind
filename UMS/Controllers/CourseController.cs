using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NpgsqlTypes;
using UMS.Application.Entities.Course.Commands;
using UMS.Application.Entities.Course.Queries.GetCourses;
using UMS.Domain.Models;
using UMS.DTO;

namespace UMS.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<CourseController> _logger;

    public CourseController(IMediator mediator,IMapper mapper,ILogger<CourseController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }
    
    [HttpGet("GetAllCourses")]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("Get All Courses execute");
        var result = await _mediator.Send(new GetCoursesQuery());
        
        return Ok(result);
    } 
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseById([FromRoute] int id)
    {
        
        var result = await _mediator.Send(new GetCourseByIdQuery
        {
            Id = id
        });
        
        return Ok(result);
    } 
    
    [HttpPost("AddCourse")]
    public async Task<IActionResult> Add([FromBody] CreateCourse c)
    {
        //TODO: Use AutoMapper for mappings
        Course course = _mapper.Map<Course>(c);

        var result = await _mediator.Send(new CreateCourseCommand
        {
            course= course
        });

        return Ok(result);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateCourseDTO c)
    {
        //TODO: Use AutoMapper for mappings
        Course course = _mapper.Map<Course>(c);

        var existCourse = await _mediator.Send(new GetCourseByIdQuery()
        {
            Id = c.Id
        });

        if (existCourse == null)
        {
            return BadRequest($"No course found with the id {c.Id}");
        }
        
        var result = await _mediator.Send(new UpdateCourseCommand()
        {
            course = course
        });

        return Ok(result);
    }
    
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var existCourse = await _mediator.Send(new GetCourseByIdQuery()
        {
            Id = id
        });

        if (existCourse == null)
        {
            return BadRequest($"No course found with the id {id}");
        }
        
        var result = await _mediator.Send(new DeleteCourseCommand()
        {
            Id = id
        });

        return Ok(result);
    }
    
}