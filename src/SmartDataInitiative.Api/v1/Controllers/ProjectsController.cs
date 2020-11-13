using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartDataInitiative.Api.ViewModels;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;
using SmartDataInitiative.Business.Models;
using SmartDataInitiative.Data.Context;

namespace SmartDataInitiative.Api.v1.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProjectsController : MainController
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;


        public ProjectsController(INotify notify,
                                  IProjectService projectService,
                                  IMapper mapper,
                                  IUser user) : base(notify, user)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectViewModel>> All() => _mapper.Map<IEnumerable<ProjectViewModel>>(await _projectService.All());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjectViewModel>> Show(Guid id)
        {
            var project = await GetProject(id);

            if (project == null) return NotFound();

            return FormattedResponse(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectViewModel>> Add(ProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid) return FormattedResponse(ModelState);

            await _projectService.Add(_mapper.Map<Project>(projectViewModel));

            return FormattedResponse(projectViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProjectViewModel>> Update(Guid id, ProjectViewModel projectViewModel)
        {
            if(id != projectViewModel.Id)
            {
                NotifyError("Id incorreto");
                return FormattedResponse(projectViewModel);
            }

            if (!ModelState.IsValid) return FormattedResponse(ModelState);

            await _projectService.Update(_mapper.Map<Project>(projectViewModel));

            return FormattedResponse(projectViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProjectViewModel>> Remove(Guid id)
        {
            var projectViewModel = await GetProject(id);

            if (projectViewModel == null) return NotFound();

            await _projectService.Remove(id);

            return FormattedResponse(projectViewModel);

        }

        private async Task<ProjectViewModel> GetProject(Guid id) => _mapper.Map<ProjectViewModel>(await _projectService.Show(id));

    }
}
