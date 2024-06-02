using Domain.Identity;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class TodoDTO
    {
        public Guid? Id { get; set; }
        public string TaskName { get; set; } = default!;
        public int? TaskSort { get; set; } = default!;
        public bool IsCompleted { get; set; } = default!;
        public Guid TodoCategoryId { get; set; } = default!;
    }
}
