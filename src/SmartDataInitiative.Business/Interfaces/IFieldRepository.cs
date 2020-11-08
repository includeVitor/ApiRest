using SmartDataInitiative.Business.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Interfaces
{
    public interface IFieldRepository : IRepository<Field>
    {
        Task<Field> GetReportsInField(Guid id);
        Task<Field> GetFeedbacksInField(Guid id);
        Task<IEnumerable<Field>> GetFieldsByProject(Guid ProjectId);

    }
}
