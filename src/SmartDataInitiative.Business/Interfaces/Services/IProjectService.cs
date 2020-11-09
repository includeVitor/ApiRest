using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Interfaces.Services
{
    public interface IProjectService : IDisposable
    {
        Task<bool> Add(Project project);
        Task<bool> Update(Project project);
        Task<bool> Remove(Guid id);
        Task<bool> SaveField(Field field);
        Task<bool> SaveReportModel(ReportModel reportModel);
    }
}
