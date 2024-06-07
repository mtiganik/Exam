using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Admin
{
    public class AdminCompanyDTO
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } = default!;
        public bool IsPublic { get; set; }
        public string SuName { get; set; } = default!;
        public string SuEmail { get; set; } = default!;
        public string SuPw { get; set; } = default!;
        public int ActivityMinutes { get; set; } = 10;
        public int Sort1 { get; set; } = 10;
        public int Sort2 { get; set; } = 10;
        public string Tag { get; set; } = default!;

    }
}
