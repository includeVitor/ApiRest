using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDataInitiative.Api.ViewModels
{
    public class ReportViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime InitialDate { get; set; }

        [Required]
        public DateTime FinalDate { get; set; }

        public ReportModel ReportModel { get; set; }
        public Field Field { get; set; }


    }
}
