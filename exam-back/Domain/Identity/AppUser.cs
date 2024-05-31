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
        [MinLength(1)]
        [MaxLength(64)]
        public string FirstName { get; set; } = default!;

        [MinLength(1)]
        [MaxLength(64)]
        public string LastName { get; set; } = default!;

        public ICollection<AppRefreshToken>? RefreshTokens { get; set; }

        public ICollection<UserInSubject> UsersInSubject { get; set; } = default!;
    }
}
