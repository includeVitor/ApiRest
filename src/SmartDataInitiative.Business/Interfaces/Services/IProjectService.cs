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
        Task<bool> Remove(Project project);
        Task<bool> SaveField(Project project);
        Task<bool> SaveReportModel(Project project);
    }
}
