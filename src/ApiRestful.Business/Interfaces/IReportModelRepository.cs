using ApiRestful.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRestful.Business.Interfaces
{
    public interface IReportModelRepository : IRepository<ReportModel>
    {
        Task<ReportModel> GetModelsInReportModel(Guid id);
        Task<ReportModel> GetProjectInReportModel(Guid id);
        Task<IEnumerable<ReportModel>> GetReportModelsByProject(Guid ProjectId);
        Task<ReportModel> GetAllInReportModel(Guid id);
        Task<IEnumerable<ReportModel>> GetAllReportModels();

    }
}
