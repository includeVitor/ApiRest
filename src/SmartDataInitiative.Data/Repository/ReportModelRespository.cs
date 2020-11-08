using Microsoft.EntityFrameworkCore;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Models;
using SmartDataInitiative.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDataInitiative.Data.Repository
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
        public async Task<ReportModel> GetReportModelsByProject(Guid ProjectId) => await
                    Db.ReportModels.AsNoTracking()
                    .Include(c => c.Project)
                    .FirstOrDefaultAsync(c => c.ProjectId == ProjectId);
      

    }
}
