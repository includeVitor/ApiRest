using SmartDataInitiative.Business.Models;
using System;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Interfaces
{
    public interface IReportModelRepository : IRepository<ReportModel>
    {
        Task<ReportModel> GetModelsInReportModel(Guid id);
        Task<ReportModel> GetProjectInReportModel(Guid id);
        Task<ReportModel> GetReportModelsByProject(Guid ProjectId);
    }
}
