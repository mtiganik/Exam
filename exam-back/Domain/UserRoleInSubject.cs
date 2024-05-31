﻿using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserRoleInSubject : BaseEntityId
    {
        public string RoleName { get; set; } = default!;
    }
}
