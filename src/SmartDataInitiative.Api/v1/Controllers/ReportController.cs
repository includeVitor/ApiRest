using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;

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


        public async Task<ReportViewModel> GetReport(Guid id) => _mapper.Map<ReportViewModel>(await _reportService.Show(id));
    }
}
