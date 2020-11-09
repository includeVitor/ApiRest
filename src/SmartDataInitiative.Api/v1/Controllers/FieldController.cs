using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;
using SmartDataInitiative.Business.Models;

namespace SmartDataInitiative.Api.v1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FieldController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IFieldService _fieldService;

        public FieldController(INotify notify,
                                IMapper mapper, 
                                IFieldService fieldService) : base(notify)
        {
            _mapper = mapper;
            _fieldService = fieldService;
        }

        [HttpGet]
        public async Task<IEnumerable<Field>> All() => _mapper.Map<IEnumerable<Field>>(await _fieldService.All());


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Field>> Show(Guid id)
        {
            var field = await _fieldService.Show(id);

            if (field == null) return NotFound();

            return FormattedResponse(field);
        }






        private async Task<Field> GetField(Guid id) => _mapper.Map<Field>(await _fieldService.Show(id));


    }
}
