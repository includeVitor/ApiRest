using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiRestful.Business.Models
{
    public class ReportModel : Entity 
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /*EF Relation */
        [JsonIgnore]
        public Project Project { get; set; }
        public IEnumerable<Model> Models { get; set; }
    }
}
