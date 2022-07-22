﻿namespace UMS.Domain.Models
{
    public partial class TeacherPerCoursePerSessionTime
    {
        public long Id { get; set; }
        public long TeacherPerCourseId { get; set; }
        public long SessionTimeId { get; set; }

        public virtual SessionTime SessionTime { get; set; } = null!;
        public virtual TeacherPerCourse TeacherPerCourse { get; set; } = null!;
    }
}
