using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Grade : BaseEntityId
    {
        public string? GradeName { get; set; }
    }
}
