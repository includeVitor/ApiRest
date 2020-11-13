using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartDataInitiative.Api.ViewModels;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;
using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDataInitiative.Api.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ReportModelsController : MainController
    {
        private readonly IReportModelService _reportModelService;
        private readonly IMapper _mapper;

        public ReportModelsController(INotify notify,
                                    IReportModelService reportModelService, 
                                    IMapper mapper,
                                    IUser user) : base(notify, user)
        {
            _reportModelService = reportModelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ReportModelViewModel>> All() => _mapper.Map<IEnumerable<ReportModelViewModel>>(await _reportModelService.All());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ReportModelViewModel>> Show(Guid id)
        {
            var reportModel = await GetReportModel(id);

            if (reportModel == null) return NotFound();

            return FormattedResponse(reportModel);
        }

        [HttpPost]
        public async Task<ActionResult<ReportModelViewModel>> Add(ReportModelViewModel reportModel)
        {

            if (!ModelState.IsValid) return FormattedResponse(ModelState);

            await _reportModelService.Add(_mapper.Map<ReportModel>(reportModel));

            return FormattedResponse(reportModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ReportModelViewModel>> Update(Guid id, ReportModelViewModel reportModel)
        {
            if(id != reportModel.Id)
            {
                NotifyError("Id incorreto");
                return FormattedResponse(reportModel);
            }

            if (!ModelState.IsValid) return FormattedResponse(ModelState);

            await _reportModelService.Update(_mapper.Map<ReportModel>(reportModel));

            return FormattedResponse(reportModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ReportModelViewModel>> Remove (Guid id)
        {
            var reportModel = await GetReportModel(id);

            if (reportModel == null) return NotFound();

            await _reportModelService.Remove(id);

            return FormattedResponse(reportModel);

        }

        public async Task<ReportModelViewModel> GetReportModel(Guid id) => _mapper.Map<ReportModelViewModel>(await _reportModelService.Show(id));

    }
}
