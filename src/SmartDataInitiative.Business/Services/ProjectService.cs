using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;
using SmartDataInitiative.Business.Models;
using SmartDataInitiative.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Services
{
    public class ProjectService : BaseService, IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(INotify notify, 
                              IProjectRepository projectRepository) : base(notify)
        {
            _projectRepository = projectRepository;
        }

        public async Task<bool> Add(Project project)
        {
            if (!ExecuteValidation(new ProjectValidation(), project)) return false;

            if (_projectRepository.Find(p => p.Name == project.Name).Result.Any())
            {
                Notify("Já existe um projeto com esse nome");
                return false;
            }

            if(DateTime.Compare(project.InitialDate,project.FinalDate) <= 0)
            {
                Notify("A data inicial deve ser maior que a data final");
                return false;
            }

            await _projectRepository.Add(project);
            return true;
        }

        public async Task<bool> Update(Project project)
        {
            if (!ExecuteValidation(new ProjectValidation(), project)) return false;

            if (_projectRepository.Find(p => p.Name == project.Name && p.Id != project.Id).Result.Any())
            {
                Notify("Já existe um projeto com esse nome");
                return false;
            }

            if (DateTime.Compare(project.InitialDate, project.FinalDate) <= 0)
            {
                Notify("A data inicial deve ser maior que a data final");
                return false;
            }

            await _projectRepository.Update(project);
            return true;
        }

        public Task<bool> Remove(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveField(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveReportModel(Project project)
        {
            throw new NotImplementedException();
        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
