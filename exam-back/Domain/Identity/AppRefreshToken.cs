using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Identity
{
    public class AppRefreshToken : BaseRefreshToken
    {
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

    }
}
