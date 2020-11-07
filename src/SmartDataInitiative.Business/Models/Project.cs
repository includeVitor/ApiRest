using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDataInitiative.Business.Models
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }

        /* EF Relation */





    }
}
