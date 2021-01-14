using ApiRestful.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRestful.Business.Interfaces
{
    public interface IReportRepository : IRepository<Report>
    {
        Task<Report> GetReportModelInReport (Guid id);
        Task<Report> GetFieldInReport(Guid id);
        Task<IEnumerable<Report>> GetReportsByReportModel(Guid ReportModelId);
        Task<IEnumerable<Report>> GetReportsByField(Guid FieldId);
        Task<Report> GetAllInReport(Guid id);
        Task<IEnumerable<Report>> GetAllReports();

    }
}
