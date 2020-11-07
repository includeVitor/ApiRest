using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDataInitiative.Business.Models
{
    public class ReportModel : Entity 
    {
        public string Name { get; set; }
        public string Description { get; set; }

        /*EF Relation */
        public Project Project { get; set; }
    }
}
