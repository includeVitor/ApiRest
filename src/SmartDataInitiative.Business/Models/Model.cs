using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDataInitiative.Business.Models
{
    public class Model : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        /*EF Relation */
        public ReportModel ReportModel { get; set; }

    }
}
