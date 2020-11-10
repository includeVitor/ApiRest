using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDataInitiative.Api.ViewModels
{
    public class FieldViewModel
    {   
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(2000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        public Status Status { get; set; }

        public Project Project { get; set; }

        public IEnumerable<Report> Reports { get; set; }

        public IEnumerable<Feedback> Feedbacks { get; set; }

    }
}
