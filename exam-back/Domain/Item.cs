using Domain.Base;
using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Item : BaseEntityId
    {
        public string ItemName { get; set; } = default!;
        public bool IsGivenOut { get; set; }
        public Guid? UserToGiveOutId { get; set; } = default!;
        public AppUser? AppUser { get; set; } = default!;
        public Guid CompanyId { get; set; } = default!;
        public Company Company { get; set; } = default!;
    }
}
