using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.SuperUser
{
    public class ItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsGivenOut { get; set; }
        public Guid UserToGiveOutId { get; set; } = default!;

    }
}
