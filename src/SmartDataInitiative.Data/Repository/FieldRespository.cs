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
    public class FieldRespository : Repository<Field>, IFieldRepository
    {
        public FieldRespository(MyDbContext context) : base(context) { }

        public async Task<IEnumerable<Field>> GetAllReportsByField(Guid id) => await
                   Db.Fields.AsNoTracking()
                   .Include(c => c.Feedbacks)
                   .Where(c => c.Id == id)
                   .ToListAsync();

        public async Task<IEnumerable<Field>> GetAllFeedbacksByField(Guid id) => await
                    Db.Fields.AsNoTracking()
                    .Include(c => c.Feedbacks)
                    .Where(c => c.Id == id)
                    .ToListAsync();

    }
}
