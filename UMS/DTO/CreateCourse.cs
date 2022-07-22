using System.ComponentModel.DataAnnotations;
using NpgsqlTypes;

namespace UMS.DTO;

public class CreateCourse
{  
    [Required]
    public string? Name { get; set; }
    [Required]
    public int? MaxStudentsNumber { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
}