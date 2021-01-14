using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiRestful.Business.Models
{
    public class Field : Entity
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }

        /*EF Relation */
        [JsonIgnore]
        public Project Project { get; set; }
        public IEnumerable<Report> Reports { get; set; }
        public IEnumerable<Feedback> Feedbacks { get; set; }
    }
}

