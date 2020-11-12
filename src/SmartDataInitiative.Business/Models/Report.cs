using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SmartDataInitiative.Business.Models
{
    public class Report : Entity
    {
        public Guid FieldId { get; set; }
        public Guid ReportModelId { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        
        /*EF Relation */
        [JsonIgnore]
        public ReportModel ReportModel { get; set; }
        [JsonIgnore]
        public Field Field { get; set; }
    }
}
