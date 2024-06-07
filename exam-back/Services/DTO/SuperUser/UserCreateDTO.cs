using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.SuperUser
{
    public class UserCreateDTO
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string UserPassword { get; set; } = default!;

    }
}
