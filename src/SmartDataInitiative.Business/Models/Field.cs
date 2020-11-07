using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SmartDataInitiative.Business.Models
{
    public class Field : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }

        /*EF Relation */
        public Project Project { get; set; }
    }
}
