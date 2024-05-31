using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Homework : BaseEntityId
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime? Deadline { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; } = default!;
        public IEnumerable<HwForStudent> HwForStudents { get; set; } = default!;
    }
}
