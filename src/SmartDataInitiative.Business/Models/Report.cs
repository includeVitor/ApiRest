using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDataInitiative.Business.Models
{
    public class Report : Entity
    {
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        
        /*EF Relation */
        public ReportModel ReportModel { get; set; }
    }
}
