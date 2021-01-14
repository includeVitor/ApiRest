using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiRestful.Api.ViewModels;
using ApiRestful.Business.Interfaces;
using ApiRestful.Business.Interfaces.Services;
using ApiRestful.Business.Models;

namespace ApiRestful.Api.v1.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ModelsController : MainController
    {
        private readonly IModelService _modelService;
        private readonly IMapper _mapper;

        public ModelsController(INotify notify,
                                IModelService modelService, 
                                IMapper mapper,
                                IUser user) : base(notify, user)
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

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ModelViewModel>> Update(Guid id, ModelViewModel modelViewModel)
        {
            if (id != modelViewModel.Id)
            {
                NotifyError("Id incorreto");
                return FormattedResponse(modelViewModel);
            }

            if (!ModelState.IsValid) return FormattedResponse(ModelState);

            await _modelService.Update(_mapper.Map<Model>(modelViewModel));

            return FormattedResponse(modelViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ModelViewModel>> Remove (Guid id)
        {
            var model = await GetModel(id);

            if (model == null) return NotFound();

            await _modelService.Remove(id);

            return FormattedResponse(model);
        }

        private async Task<ModelViewModel> GetModel(Guid id) => _mapper.Map<ModelViewModel>(await _modelService.Show(id));
    }
}
