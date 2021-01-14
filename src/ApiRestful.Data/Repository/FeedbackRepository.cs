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

        public async Task<IEnumerable<Feedback>> GetFeedbacks() => await
           Db.Feedbacks.AsNoTracking()
           .Include(c => c.Field)
           .ToListAsync();

    }
}
