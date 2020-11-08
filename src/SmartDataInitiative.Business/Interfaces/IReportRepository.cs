using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Interfaces
{
    public interface IReportRepository : IRepository<Report>
    {
        Task<Report> GetReportModelInReport (Guid id);
        Task<Report> GetFieldInReport(Guid id);
        Task<IEnumerable<Report>> GetReportsByReportModel(Guid ReportModelId);
        Task<IEnumerable<Report>> GetReportsByField(Guid FieldId);

    }
}
