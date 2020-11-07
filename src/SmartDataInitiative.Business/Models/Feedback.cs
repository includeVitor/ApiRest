using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDataInitiative.Business.Models
{
    public class Feedback : Entity
    {
        public Guid FieldId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FeedbackType FeedbackType { get; set; }

        /* EF Relation */
        public Field Field { get; set; }
    }
}
