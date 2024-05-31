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
        public ICollection<HwForStudent> HwsForStudent { get; set; } = default!;
        public ICollection<UserInSubject> UsersInSubject { get; set; } = default!;
    }
}
