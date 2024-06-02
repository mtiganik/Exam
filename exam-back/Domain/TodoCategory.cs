using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TodoCategory : BaseEntityId
    {
        public string CategoryName { get; set; } = default!;
        public int CategorySort { get; set; } = default!;
        public ICollection<TodoCategory>? TodoCategories { get; set; }
    }
}
