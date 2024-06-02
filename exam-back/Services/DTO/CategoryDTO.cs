﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class CategoryDTO
    {
        public Guid? Id { get; set; }
        public string CategoryName { get; set; } = default!;
        public int? CategorySort { get; set; } = default!;

    }
}
