using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class FrontPageSubjectDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Teacher { get; set; }
        public int? StudentsCnt { get; set; }

        public string? SemesterName { get; set; } 

    }
}
