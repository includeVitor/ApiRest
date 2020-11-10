]using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;
using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDataInitiative.Api.v1.Controllers
{
    public class ReportModelController : MainController
    {
        private readonly IReportModelService _reportModelService;
        private readonly IMapper _mapper;

        public ReportModelController(INotify notify,
                                    IReportModelService reportModelService, 
                                    IMapper mapper) : base(notify)
        {
            _reportModelService = reportModelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ReportModel>> All() => _mapper.Map<IEnumerable<ReportModel>>(await _reportModelService.All());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ReportModel>> Show(Guid id)
        {
            var reportModel = await GetReportModel(id);

            if (reportModel == null) return NotFound();

            return FormattedResponse(reportModel);
        }



        public async Task<ReportModel> GetReportModel(Guid id) => _mapper.Map<ReportModel>(await _reportModelService.Show(id));

    }
}
