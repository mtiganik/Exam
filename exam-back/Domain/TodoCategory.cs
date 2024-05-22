using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TodoCategory
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = default!;
        public int CategorySort { get; set; }
        public List<Todo>? Todos { get; set; }
    }
}
