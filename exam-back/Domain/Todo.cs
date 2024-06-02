using Domain.Base;
using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Todo : BaseEntityId
    {
        public string TaskName { get; set; } = default!;
        public int? TaskSort { get; set; } = default!;
        public bool IsCompleted { get; set; } = default!;
        public Guid AppUserId { get; set; } 
        public AppUser AppUser { get; set; } = default!;
        public Guid TodoCategoryId {get; set;} = default!; 
        public TodoCategory Category { get; set; } = default!;
    }
}
