using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Semester : BaseEntityId
    {
        public string SemesterName { get; set; } = default!;
    }
}
