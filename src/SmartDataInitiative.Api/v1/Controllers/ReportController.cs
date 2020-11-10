using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartDataInitiative.Api.ViewModels;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;
using SmartDataInitiative.Business.Models;

namespace SmartDataInitiative.Api.v1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ReportController : MainController
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public ReportController(INotify notify, 
                                IReportService reportService, 
                                IMapper mapper) : base(notify)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReportViewModel>> All() => _mapper.Map<IEnumerable<ReportViewModel>>(await _reportService.All());

        public async Task<ActionResult<ReportViewModel>> Show(Guid id)
        {
            var report = await GetReport(id);

            if (report == null) return NotFound();

            return FormattedResponse(report);
        }

        public async Task<ActionResult<ReportViewModel>> Add(ReportViewModel reportViewModel)
        {
            if (!ModelState.IsValid) return FormattedResponse(ModelState);

            await _reportService.Add(_mapper.Map<Report>(reportViewModel));

            return FormattedResponse(reportViewModel);
        }


        public async Task<ReportViewModel> GetReport(Guid id) => _mapper.Map<ReportViewModel>(await _reportService.Show(id));
    }
}
