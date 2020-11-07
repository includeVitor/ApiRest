using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDataInitiative.Business.Models
{
    public class Report : Entity
    {
        public Guid FieldId { get; set; }
        public Guid ReportModelId { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        
        /*EF Relation */
        public ReportModel ReportModel { get; set; }
        public Field Field { get; set; }
    }
}
