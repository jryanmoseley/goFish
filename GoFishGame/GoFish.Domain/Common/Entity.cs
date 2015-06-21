using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Common
{
    public class Entity
    {
        public Entity()
        {
            Events = new List<IDomainEvent>();
        }

        public List<IDomainEvent> Events { get; protected set; }
    }
}
