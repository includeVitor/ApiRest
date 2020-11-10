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








        public async Task<ModelViewModel> GetModel(Guid id) => _mapper.Map<ModelViewModel>(await _modelService.Show(id));






    }
}
