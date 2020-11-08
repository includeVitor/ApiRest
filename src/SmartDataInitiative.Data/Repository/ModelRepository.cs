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
    public class ModelRepository : Repository<Model>, IModelRespository
    {
        public ModelRepository(MyDbContext context) : base(context) { }

        public async Task<IEnumerable<Model>> GetModelsByReportModel(Guid ReportModelId) => await
                   Db.Models.AsNoTracking()
                   .Where(c => c.ReportModelId == ReportModelId)
                   .ToListAsync();

        public async Task<Model> GetReportModelInModel(Guid id) => await
                   Db.Models.AsNoTracking()
                   .FirstOrDefaultAsync(c => c.Id == id);

    }
}
