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
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ModelsController : MainController
    {
        private readonly IModelService _modelService;
        private readonly IMapper _mapper;

        public ModelsController(INotify notify,
                                IModelService modelService, 
                                IMapper mapper) : base(notify)
        {
            _modelService = modelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ModelViewModel>> All() => _mapper.Map<IEnumerable<ModelViewModel>>(await _modelService.All());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ModelViewModel>> Show(Guid id)
        {
            var reportModel = await GetModel(id);

            if (reportModel == null) return NotFound();

            return FormattedResponse(reportModel);
        }

        [HttpPost]
        public async Task<ActionResult<ModelViewModel>> Add(ModelViewModel modelViewModel)
        {
            if (!ModelState.IsValid) return FormattedResponse(ModelState);

            await _modelService.Add(_mapper.Map<Model>(modelViewModel));

            return FormattedResponse(modelViewModel);
        }






        public async Task<ModelViewModel> GetModel(Guid id) => _mapper.Map<ModelViewModel>(await _modelService.Show(id));






    }
}
