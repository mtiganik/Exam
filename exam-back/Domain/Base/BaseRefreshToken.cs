using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public class BaseRefreshToken : BaseRefreshToken<Guid>
    {
    }

    public class BaseRefreshToken<TKey> : BaseEntityId<TKey>
    where TKey : IEquatable<TKey>
    {
        [MaxLength(64)]
        public string RefreshToken { get; set; } = Guid.NewGuid().ToString();
        public DateTime ExpirationDT { get; set; } = DateTime.UtcNow.AddDays(7);


        [MaxLength(64)]
        public string? PreviousRefreshToken { get; set; }
        public DateTime PreviousExpirationDT { get; set; } = DateTime.UtcNow.AddDays(7);
    }
}
