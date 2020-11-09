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
        private readonly IReportModelRepository _reportModelRepository;
        private readonly IFieldRepository _fieldRepository;

        public ProjectService(INotify notify,
                              IProjectRepository projectRepository, 
                              IFieldRepository fieldRepository, 
                              IReportModelRepository reportModelRepository) : base(notify)
        {
            _projectRepository = projectRepository;
            _fieldRepository = fieldRepository;
            _reportModelRepository = reportModelRepository;
        }
        
        public async Task<IEnumerable<Project>> All() => await _projectRepository.GetAllProjects();

        public async Task<Project> Show(Guid id) => await _projectRepository.GetAllInProjects(id);   

        public async Task<bool> Add(Project project)
        {
            if (!ExecuteValidation(new ProjectValidation(), project)) return false;

            if (_projectRepository.Find(p => p.Name == project.Name && p.Id == project.Id).Result.Any())
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

        public async Task<bool> Remove(Guid id)
        {
            var reportModels = await _reportModelRepository.GetReportModelsByProject(id);

            if(reportModels != null)
            {
                foreach (var reportModel in reportModels)
                {
                    await _reportModelRepository.Remove(reportModel.Id);
                }
            }

            var fields = await _fieldRepository.GetFieldsByProject(id);

            if (fields != null)
            {
                foreach (var field in fields)
                {
                    await _reportModelRepository.Remove(field.Id);
                }
            }

            await _projectRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _projectRepository?.Dispose();
            _fieldRepository?.Dispose();
            _reportModelRepository?.Dispose();
        }
    }
}
