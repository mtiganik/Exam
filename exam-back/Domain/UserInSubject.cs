using Domain.Base;
using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserInSubject :BaseEntityId
    {
        public bool IsAccepted { get; set; } = default!;
        public bool IsCompleted { get; set; } = default!;
        public Guid? FinalGradeId { get; set; } = default!;   
        public Guid UserId { get; set; }
        public AppUser User { get; set; } = default!;
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; } = default!;
        public Guid UserRoleInSubjectId { get; set;} = default!;
        public UserRoleInSubject UserRoleInSubject { get; set; } = default!;
        public ICollection<HwForStudent> HwsForStudent { get; set; } = default!;

    }
}
