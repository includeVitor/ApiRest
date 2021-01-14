using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRestful.Business.Models.Validations
{
    public class ReportValidation : AbstractValidator<Report>
    {
        public ReportValidation()
        {
            RuleFor(p => p.InitialDate).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.FinalDate).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
