using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public class FieldsController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IFieldService _fieldService;

        public FieldsController(INotify notify,
                                IMapper mapper, 
                                IFieldService fieldService,
                                IUser user) : base(notify, user)
        {
            _mapper = mapper;
            _fieldService = fieldService;
        }

        [HttpGet]
        public async Task<IEnumerable<FieldViewModel>> All() => _mapper.Map<IEnumerable<FieldViewModel>>(await _fieldService.All());


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FieldViewModel>> Show(Guid id)
        {
            var field = await GetField(id);

            if (field == null) return NotFound();

            return FormattedResponse(field);
        }

        [HttpPost]
        public async Task<ActionResult<FieldViewModel>> Add(FieldViewModel fieldViewModel)
        {
            if (!ModelState.IsValid) return FormattedResponse(ModelState);

            await _fieldService.Add(_mapper.Map<Field>(fieldViewModel));

            return FormattedResponse(fieldViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FieldViewModel>> Update(Guid id, FieldViewModel fieldViewModel)
        {
            if(id != fieldViewModel.Id)
            {
                NotifyError("Id incorreto");
                return FormattedResponse(fieldViewModel);
            }

            if(!ModelState.IsValid) return FormattedResponse(ModelState);

            await _fieldService.Update(_mapper.Map<Field>(fieldViewModel));

            return FormattedResponse(fieldViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FieldViewModel>> Remove(Guid id)
        {
            var field = await GetField(id);

            if (field == null) return NotFound();

            await _fieldService.Remove(id);

            return FormattedResponse(field);
        }

        private async Task<FieldViewModel> GetField(Guid id) => _mapper.Map<FieldViewModel>(await _fieldService.Show(id));


    }
}
