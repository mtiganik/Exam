using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.FrontPage
{
    public class FrontPageDTO
    {
        public Guid CompanyId { get; set; } = default!;
        public string CompanyName { get; set; } = default!;

    }
}
