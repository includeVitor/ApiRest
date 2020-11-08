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
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(MyDbContext context) : base(context) { }

        public async Task<IEnumerable<Feedback>> GetFeedbacksByField(Guid FieldId) => await
                Db.Feedbacks.AsNoTracking()
                .Where(c => c.FieldId == FieldId)
                .ToListAsync();

        public async Task<Feedback> GetFieldInFeedback(Guid id) => await
              Db.Feedbacks.AsNoTracking()
              .Include(c => c.Field)
              .FirstOrDefaultAsync(c => c.Id == id);

    }
}
