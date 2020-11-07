using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<IEnumerable<Project>> GetAllFieldsByProject(Guid id);
        Task<IEnumerable<Project>> GetAllReportModelsByProject(Guid id);
    }
}
