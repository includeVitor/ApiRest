using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SmartDataInitiative.Business.Models
{
    public class Model : Entity
    {
        public Guid ReportModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /*EF Relation */
        [JsonIgnore]
        public ReportModel ReportModel { get; set; }

    }
}
