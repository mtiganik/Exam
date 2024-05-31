using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class StudentHwDTO
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string StudentName { get; set; } = default!;
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; } = default!;
        public DateTime? Deadline { get; set; }
        public DateTime? DateDone { get; set; }
        public string? GradeAsString { get; set; } = default!;


    }
}
