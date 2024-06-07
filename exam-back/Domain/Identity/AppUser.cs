using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        //[MinLength(1)]
        //[MaxLength(64)]
        //public string FirstName { get; set; } = default!;

        //[MinLength(1)]
        //[MaxLength(64)]
        //public string LastName { get; set; } = default!;
        public int ActivityMinutes { get; set; }
        public ICollection<AppRefreshToken>? RefreshTokens { get; set; }
        public ICollection<Item>? Items { get; set; }

        //public ICollection<Todo> UserTodos { get; set; } = default!;
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = default!;
    }
}
