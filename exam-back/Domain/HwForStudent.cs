using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class HwForStudent : BaseEntityId
    {
        public DateTime? DateDone { get; set; }
        public Grade Grade { get; set; } = default!;
        public bool IsDone { get; set; } 

    }
}
