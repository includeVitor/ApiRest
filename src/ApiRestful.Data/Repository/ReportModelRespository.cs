using Microsoft.EntityFrameworkCore;
using ApiRestful.Business.Interfaces;
using ApiRestful.Business.Models;
using ApiRestful.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestful.Data.Repository
{
    public class ReportModelRespository : Repository<ReportModel>, IReportModelRepository
    {
        public ReportModelRespository(MyDbContext context) : base(context) { }

        public async Task<ReportModel> GetModelsInReportModel(Guid id) => await
                    Db.ReportModels.AsNoTracking()
                    .Include(c => c.Models)
                    .FirstOrDefaultAsync(c => c.Id == id);
        public async Task<ReportModel> GetProjectInReportModel(Guid id) => await
                    Db.ReportModels.AsNoTracking()
                    .Include(c => c.Project)
                    .FirstOrDefaultAsync(c => c.Id == id);
        public async Task<IEnumerable<ReportModel>> GetReportModelsByProject(Guid ProjectId) => await
                    Db.ReportModels.AsNoTracking()
                    .Where(c => c.ProjectId == ProjectId)
                    .ToListAsync();

        public async Task<ReportModel> GetAllInReportModel(Guid id) => await
                    Db.ReportModels.AsNoTracking()
                    .Include(c => c.Models)
                    .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<ReportModel>> GetAllReportModels() => await
                 Db.ReportModels.AsNoTracking()
                 .Include(c => c.Models)
                 .ToListAsync();


    }
}
