using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDataInitiative.Business.Models
{
    abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

    }
}
