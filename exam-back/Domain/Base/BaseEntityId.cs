using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public abstract class BaseEntityId : BaseEntityId<Guid>
    {
    }
    public abstract class BaseEntityId<TKey>
    {
        public TKey Id { get; set; } = default!;
    }

}
