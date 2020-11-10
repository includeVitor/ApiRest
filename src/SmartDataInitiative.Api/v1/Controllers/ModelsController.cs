using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


        public ModelsController(INotify notify, 
                                IModelService modelService) : base(notify)
        {
            _modelService = modelService;
        }

        






    }
}
