using System.ComponentModel.DataAnnotations;

namespace UMS.DTO;

public class TeacherPerCourseDTO
{
    [Required]
    public long TeacherId { get; set; }
    
    [Required]
    public long CourseId { get; set; }
    
    [Required]
    public DateTime StartTime { get; set; }
    
    [Required]
    public DateTime EndTime { get; set; }
}