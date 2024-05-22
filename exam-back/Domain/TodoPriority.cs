using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TodoPriority
    {
        public Guid Id { get; set; }
        public string PriorityName { get; set; } = default!;
        public int PrioritySort { get; set;}
        public ICollection<Todo>? Todos { get; set; } 
    }
}
