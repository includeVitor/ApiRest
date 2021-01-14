using Newtonsoft.Json;
using ApiRestful.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestful.Api.ViewModels
{
    public class ReportViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime InitialDate { get; set; }

        [Required]
        public DateTime FinalDate { get; set; }

        [ForeignKey("ReportModel")]
        public Guid ReportModelId { get; set; }

        [ForeignKey("Field")]
        public Guid FieldId { get; set; }

        public ReportModel ReportModel { get; set; }

        public Field Field { get; set; }


    }
}
