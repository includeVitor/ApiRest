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

        [HttpGet]
        public async Task<IEnumerable<ReportViewModel>> All() => _mapper.Map<IEnumerable<ReportViewModel>>(await _reportService.All());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ReportViewModel>> Show(Guid id)
        {
            var report = await GetReport(id);

            if (report == null) return NotFound();

            return FormattedResponse(report);
        }

        [HttpPost]
        public async Task<ActionResult<ReportViewModel>> Add(ReportViewModel reportViewModel)
        {
            if (!ModelState.IsValid) return FormattedResponse(ModelState);

            await _reportService.Add(_mapper.Map<Report>(reportViewModel));

            return FormattedResponse(reportViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ReportViewModel>> Update(Guid id, ReportViewModel reportViewModel)
        {
            if (id == reportViewModel.Id)
            {
                NotifyError("Id incorreto");
                return FormattedResponse(reportViewModel);
            }

            if (!ModelState.IsValid) return FormattedResponse(ModelState);

            await _reportService.Update(_mapper.Map<Report>(reportViewModel));

            return FormattedResponse(reportViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ReportViewModel>> Remove(Guid id)
        {
            var report = await GetReport(id);

            if (report == null) return NotFound();

            await _reportService.Remove(id);

            return FormattedResponse(report);
        }


        public async Task<ReportViewModel> GetReport(Guid id) => _mapper.Map<ReportViewModel>(await _reportService.Show(id));
    }
}
