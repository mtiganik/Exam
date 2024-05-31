using Domain.Base;
using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Subject : BaseEntityId
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        public Guid SemesterId { get; set; }
        public Semester Semester { get; set; } = default!;
        //public AppUser Teacher { get; set; } = default!;
        public ICollection<Homework>? Homeworks { get; set; }
        public ICollection<UserInSubject>? UsersInSubject { get; set; }

    }
}
