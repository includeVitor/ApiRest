]using AutoMapper;
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
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public ReportModelController(INotify notify,
                                    IReportService reportService, 
                                    IMapper mapper) : base(notify)
        {
            _reportService = reportService;
            _mapper = mapper;
        }





        public async Task<ReportModel> GetReportModel(Guid id) => _mapper.Map<ReportModel>(await _reportService.Show(id));

    }
}
