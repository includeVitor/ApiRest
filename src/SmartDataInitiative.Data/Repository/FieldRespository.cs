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
    public class FieldRespository : Repository<Field>, IFieldRepository
    {
        public FieldRespository(MyDbContext context) : base(context) { }

        public async Task<Field> GetReportsInField(Guid id) => await
                   Db.Fields.AsNoTracking()
                   .Include(c => c.Reports)
                   .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Field> GetFeedbacksInField(Guid id) => await
                    Db.Fields.AsNoTracking()
                    .Include(c => c.Feedbacks)
                    .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<Field>> GetFieldsByProject(Guid ProjectId) => await
                    Db.Fields.AsNoTracking()
                    .Where(c => c.ProjectId == ProjectId)
                    .ToListAsync();

        public async Task<Field> GetAllInFields(Guid id) => await
                  Db.Fields.AsNoTracking()
                  .Include(c => c.Reports)
                  .Include(c => c.Feedbacks)
                  .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<Field>> GetAllFields() => await
               Db.Fields.AsNoTracking()
               .Include(c => c.Reports)
               .Include(c => c.Feedbacks)
               .ToListAsync();

    }
}
