using Domain.Base;
using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Company : BaseEntityId
    {
        public string CompanyName { get; set; } = default!;
        public bool IsPublic { get; set; }
        public string SuName { get; set; } = default!;
        public string SuEmail { get; set; } = default!;
        public string SuPw { get; set; } = default!;
        public int ActivityMinutes { get; set;} = default!;
        public int Sort1 { get; set; } = default!;
        public int Sort2 { get; set; } = default!;
        public string Tag { get; set; } = default!;
        public ICollection<Item> Items { get; set; } = default!;
        public ICollection<AppUser> AppUsers { get; set; } = default!;

    }
}
