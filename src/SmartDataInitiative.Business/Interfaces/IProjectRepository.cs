using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> GetFieldsInProject(Guid id);
        Task<Project> GetReportModelsInProject(Guid id);
        Task<Project> GetAllInProjects(Guid id);
        Task<IEnumerable<Project>> GetAllProjects();

    }
}
