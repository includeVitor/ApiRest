using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Interfaces.Services
{
    public interface IReportModelService : IDisposable
    {
        Task<IEnumerable<ReportModel>> All();
        Task<ReportModel> Show(Guid id);
        Task<bool> Add(ReportModel reportModel);
        Task<bool> Update(ReportModel reportModel);
        Task<bool> Remove(Guid id);
    }
}
