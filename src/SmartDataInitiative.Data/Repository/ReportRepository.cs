using Microsoft.EntityFrameworkCore;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Models;
using SmartDataInitiative.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDataInitiative.Data.Repository
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(MyDbContext context) : base(context) { }

        public async Task<Report> GetFieldInReport(Guid id) => await
                Db.Reports.AsNoTracking()
                .Include(c => c.Field)
                .FirstOrDefaultAsync(c => c.Id == id);
        

        public async Task<Report> GetReportModelInReport(Guid id) => await
                Db.Reports.AsNoTracking()
                .Include(c => c.ReportModel)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<Report>> GetReportsByField(Guid FieldId) => await
                 Db.Reports.AsNoTracking()
                .Where(c => c.FieldId == FieldId)
                .ToListAsync();

        public async Task<IEnumerable<Report>> GetReportsByReportModel(Guid ReportModelId) => await
                Db.Reports.AsNoTracking()
                .Where(c => c.ReportModelId == ReportModelId)
                .ToListAsync();

    }
}
